using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : EnemyBehavior
{
    public override void Awake()
    {
        base.Awake();
        SetCurrentAbility(new FireProjectileAbility());
    }
}
