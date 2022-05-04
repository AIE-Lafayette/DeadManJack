using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovementBehavior : EnemyMovementBehavior
{
    /// <summary>
    /// How far the enemy can be from the player before attacking.
    /// </summary>
    [SerializeField]
    private float _maxRange;

    [SerializeField]
    private float _seekDistance;

    private void Awake()
    {
        _seekDistance += Target.transform.position.z;
    }

    // Update is called once per frame
    public override void Update()
    {
        Vector3 direction = Target.position - transform.position;

        // Finds the distance between the player and the enemy.
        bool playerInRange = direction.magnitude < _maxRange;

        if (!playerInRange)
        {
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
}
