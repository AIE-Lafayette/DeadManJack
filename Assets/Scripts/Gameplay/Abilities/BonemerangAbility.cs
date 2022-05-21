using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonemerangAbility : Ability
{
    public void MoveToOwner()
    {
        Rigidbody bonemerang = VisualPrefab.GetComponent<Rigidbody>();

        if (bonemerang)
            bonemerang.AddForce((Owner.transform.position + VisualPrefab.transform.position).normalized * 5, ForceMode.Impulse);  
    }

    public override void Activate(params object[] arguments)
    {
        RoutineBehavior instance = RoutineBehavior.Instance;

        instance.StartNewTimedAction(arguments => MoveToOwner(), TimedActionCountType.SCALEDTIME, 3f);

        // Gets the owner's fist behavior.
        PlayerFistBehavior playerFist = Owner.GetComponent<PlayerFistBehavior>();
        // Gets the owner's current bullet.
        BulletBehavior playerShot = playerFist.RightFist.BulletRef;
        // Gets the bullet that will be replacing the current one.
        BulletBehavior chargeShot = VisualPrefab.GetComponent<BulletBehavior>();

        // Sets the current bullet to the new one.
        playerFist.RightFist.BulletRef = chargeShot;

        // Fires the new bullet.
        playerFist.RightFist.Fire();

        // Changes the player's bullet back to the original bullet.
        playerFist.RightFist.BulletRef = playerShot;

        base.Activate(arguments);
    }
}
