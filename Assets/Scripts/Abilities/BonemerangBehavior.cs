using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonemerangBehavior : BulletBehavior
{
    /// <summary>
    /// The seek behavior attached to the bonemerang.
    /// </summary>
    private SeekBehavior _seekBehavior;

    private bool _canBeCaught = false;

    private RoutineBehavior.TimedAction _moveToOwner;

    /// <summary>
    /// The bonemerang will begin to seek whatever it was that threw it.
    /// </summary>
    public void MoveToOwner()
    {
        _seekBehavior.Target = Owner.transform;

        // Allows the bonemerang to now be caught by whatever threw it.
        _canBeCaught = true;
    }

    protected override void Awake()
    {
        base.Awake();
        _seekBehavior = GetComponent<SeekBehavior>();
        _moveToOwner = RoutineBehavior.Instance.StartNewTimedAction(arguments => MoveToOwner(), TimedActionCountType.SCALEDTIME, 0.45f);
    }

    private void Update()
    {
        if(GameManagerBehavior.GameShouldEnd)
        {
            RoutineBehavior.Instance.StopTimedAction(_moveToOwner);
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyBehavior>())
            ScoreCounterBehavior.Instance.IncreaseScore(100);

        // If the other is the player and it can be caught...
        if(other.GetComponent<PlayerFistBehavior>() && _canBeCaught)
        {
            // ...set the ability to be a new bonemerang ability. Put that ability on a timer, and then destroy this object.
            UseAbilityBehavior playerAbility = other.GetComponent<PlayerFistBehavior>().CurrentPlayerAbility;
            playerAbility.CurrentAbility = new FireProjectileAbility();
            playerAbility.CurrentAbility.VisualPrefab = playerAbility.GetComponentInChildren<GrappleBehavior>().Bonemerang;
            playerAbility.CurrentAbility.Owner = Owner;

            ScoreCounterBehavior.Instance.IncreaseScore(50);

            Destroy(gameObject);
        }

        base.OnTriggerEnter(other);
    }
}
