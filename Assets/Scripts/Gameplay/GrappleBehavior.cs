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
    /// The mesh of the grab.
    /// </summary>
    private MeshRenderer _meshRenderer;

    /// <summary>
    /// Disables the collider and mesh renderer if they are enabled and enables them otherwise.
    /// </summary>
    private void ToggleGrab()
    {
        // If both are disabled...
        if (_sphereCollider.enabled == false && _meshRenderer.enabled == false)
        {
            // ...enable both of them.
            _sphereCollider.enabled = true;
            _meshRenderer.enabled = true;
        }
        // If they are both enabled...
        else
        {
            // ...disable them both.
            _sphereCollider.enabled = false;
            _meshRenderer.enabled = false;
        }
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
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyBehavior enemyAbility = other.gameObject.GetComponent<EnemyBehavior>();
        UseAbilityBehavior playerAbility = _owner.GetComponent<UseAbilityBehavior>();

        if (enemyAbility)
        {
            playerAbility.CurrentAbility = enemyAbility.CurrentAbility;
            playerAbility.CurrentAbility.Owner = _owner;
            Destroy(other.gameObject);
            GameManagerBehavior.EnemyCount--;
        }
    }
}
