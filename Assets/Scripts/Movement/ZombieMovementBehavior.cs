using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovementBehavior : EnemyMovementBehavior
{
    [SerializeField]
    private float _seekDistance;

    // Update is called once per frame
    public override void Update()
    {
        Vector3 direction = Target.position - transform.position;

        if (transform.position.z < _seekDistance)
        {
            Velocity = direction.normalized * Speed;
            transform.LookAt(Target);
        }
        else
            Velocity = new Vector3(0, 0, -1) * Speed;

        base.Update();
    }
}
