using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonemerangBehavior : BulletBehavior
{
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
}
