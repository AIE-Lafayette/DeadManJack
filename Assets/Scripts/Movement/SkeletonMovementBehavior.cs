using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovementBehavior : EnemyMovementBehavior
{
    public override void Update()
    {
        Velocity = new Vector3(0, 0, -1);

        base.Update();
    }

    public override void OnBeingGrabbed(PlayerFistBehavior player)
    {
        
    }
}
