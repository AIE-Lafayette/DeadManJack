using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovementBehavior : EnemyMovementBehavior
{
    public override void Update()
    {
        //Gets the direction of the target from the Zombie
        Vector3 direction = Target.position - transform.position;

        Velocity = direction.normalized;

        base.Update();
    }

    public override void OnBeingGrabbed(PlayerFistBehavior player)
    {
        if (!player)
            return;

        base.OnBeingGrabbed(player);
        player.CurrentAbility = Ability.ZOMBIE;
    }
}
