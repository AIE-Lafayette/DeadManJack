using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : EnemyBehavior
{
    public override void Awake()
    {
        base.Awake();
        SetCurrentAbility(new ZombieAbility());
    }

    public override void Update()
    {
        //Gets the direction and distance of the target from the Zombie
        float distanceFromTarget = transform.position.z - Target.transform.position.z;
        Vector3 direction = Target.transform.position - transform.position;

        //If the distance of the Target is greater than the approach distance, continue moving down on the z-axis
        if (distanceFromTarget > Movement.ApproachDistance)
            Movement.Velocity = new Vector3(0, 0, -1);
        else
        {
            Movement.Velocity = direction.normalized;
            transform.LookAt(Target.transform);
        }
    }
}
