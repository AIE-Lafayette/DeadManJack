using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectralResidueBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // The enemy movement behavior that may be attached to the other this object is colliding with.
        EnemyMovementBehavior enemy = other.GetComponent<EnemyMovementBehavior>();

        // Halves the enemy's speed.
        enemy.Speed = enemy.Speed / 2;
    }

    private void OnTriggerExit(Collider other)
    {
        // The enemy movement behavior that may be attached to the other this object is colliding with.
        EnemyMovementBehavior enemy = other.GetComponent<EnemyMovementBehavior>();
        
        // Doubles the enemy's speed.
        enemy.Speed = enemy.Speed * 2;
    }
}
