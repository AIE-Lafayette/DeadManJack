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

    // Update is called once per frame
    public override void Update()
    {
        // Finds the distance between the player and the enemy.
        bool playerInRange = (Target.transform.position - transform.position).magnitude < _maxRange;

        if (!playerInRange)
            base.Update();
    }
}
