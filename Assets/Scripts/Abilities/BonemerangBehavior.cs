using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonemerangBehavior : BulletBehavior
{
    /// <summary>
    /// The seek behavior attached to the bonemerang.
    /// </summary>
    private SeekBehavior _seekBehavior;

    public void MoveToOwner()
    {
        _seekBehavior.Target = Owner.transform;
    }

    protected override void Awake()
    {
        base.Awake();
        _seekBehavior = GetComponent<SeekBehavior>();
        RoutineBehavior.Instance.StartNewTimedAction(arguments => MoveToOwner(), TimedActionCountType.SCALEDTIME, 1f);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyBehavior>())
            ScoreCounterBehavior.Instance.IncreaseScore(100);

        base.OnTriggerEnter(other);
    }
}
