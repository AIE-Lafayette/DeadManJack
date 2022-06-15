using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleBehavior : MonoBehaviour
{
    /// <summary>
    /// The actor who has the ability to grab.
    /// </summary>
    [SerializeField]
    private GameObject _owner;

    /// <summary>
    /// The collider of the grab.
    /// </summary>
    private SphereCollider _sphereCollider;

    /// <summary>
    /// The bonemerang prefab that can be grabbed to add another.
    /// </summary>
    [SerializeField]
    private GameObject _bonemerang;

    private bool _isGrabbing = false;

    public GameObject Bonemerang { get { return _bonemerang; } }

    /// <summary>
    /// Disables the collider and mesh renderer if they are enabled and enables them otherwise.
    /// </summary>
    private void ToggleGrab()
    {
        // If it is disabled...
        if (_sphereCollider.enabled == false)
            // ...enable it.
            _sphereCollider.enabled = true;
        // If it is enabled...
        else
            // ...disable is.
            _sphereCollider.enabled = false;
    }

    public void ToggleCanGrapple()
    {
        if (_isGrabbing)
            _isGrabbing = false;
        else
            _isGrabbing = true;
    }

    /// <summary>
    /// Turns on the grapple for the player allowing them to grab an enemy.
    /// </summary>
    public void Activate()
    {
        // Creates an instance of the Routine Behavior or copies the instance of it.
        RoutineBehavior routineBehavior = RoutineBehavior.Instance;
        ToggleGrab();
        // Attempts to set up a timed action where the grab radius will be set back to inactive.
       routineBehavior.StartNewTimedAction(arguments => ToggleGrab(), TimedActionCountType.SCALEDTIME, 0.5f);
    }

    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Gets the ability for the player and for the enemy.
        EnemyBehavior enemyAbility = other.gameObject.GetComponent<EnemyBehavior>();
        UseAbilityBehavior playerAbility = _owner.GetComponent<UseAbilityBehavior>();

        if (enemyAbility && !_isGrabbing)
        {
            if (other.GetComponent<HealthBehavior>().IsInvulnerable)
                return;

            // Sets the player's ability to be a copy of the enemy's ability.
            playerAbility.CurrentAbility = enemyAbility.CurrentAbility;
            playerAbility.CurrentAbility.Owner = _owner;
            // Destroys the enemy and subtracts from the enemy count.
            Destroy(other.gameObject);
            GameManagerBehavior.EnemyCount--;
            // Stops the player from grabbing for a moment, until the timed action is called.
            _isGrabbing = true;
            RoutineBehavior.Instance.StartNewTimedAction(arguments => ToggleCanGrapple(), TimedActionCountType.SCALEDTIME, 0.45f);
            // Increases the score based on the enemy's score count.
            ScoreCounterBehavior.Instance.IncreaseScore(enemyAbility.ScoreAmount * 2);

            // If the player ability is not a bonemerang...
            if (!playerAbility.VisualPrefab.GetComponent<BonemerangBehavior>())
                // ...sets a timer for the ability to be taken away.
                RoutineBehavior.Instance.StartNewTimedAction(arguments => _owner.GetComponent<PlayerFistBehavior>().LoseAbility(), TimedActionCountType.SCALEDTIME, 5f);
        }
    }
}