using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : EnemyBehavior
{
    
    public override void Awake()
    {
        base.Awake();
        //SetCurrentAbility(new GhostAbility());
    }
}
