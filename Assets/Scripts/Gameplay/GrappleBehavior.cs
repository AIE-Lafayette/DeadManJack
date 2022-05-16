using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleBehavior : MonoBehaviour
{
    /// <summary>
    /// The area where the player will be able to grab.
    /// </summary>
    [SerializeField]
    private GameObject _grabRadius;

    /// <summary>
    /// The area where the player will be able to grab.
    /// </summary>
    public GameObject GrabRadius
    {
        get { return _grabRadius; }
        set { _grabRadius = value; }
    }

    /// <summary>
    /// Turns on the grapple for the player allowing them to grab an enemy.
    /// </summary>
    public void Activate()
    {
        // Creates an instance of the Routine Behavior or copies the instance of it.
        RoutineBehavior routineBehavior = RoutineBehavior.Instance;
        _grabRadius.SetActive(true);
        // Attempts to set up a timed action where the grab radius will be set back to inactive.
       routineBehavior.StartNewTimedAction(arguments => _grabRadius.SetActive(false), TimedActionCountType.SCALEDTIME, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyBehavior enemyAbility = other.gameObject.GetComponent<EnemyBehavior>();

        if (enemyAbility)
        {
            GetComponent<PlayerFistBehavior>().CurrentPlayerAbility.CurrentAbility = enemyAbility.CurrentAbility;
            Destroy(other.gameObject);
        }
    }
}
