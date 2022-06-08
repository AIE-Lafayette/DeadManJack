using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectralResidueBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // The enemy movement behavior that may be attached to the other this object is colliding with.
        EnemyMovementBehavior enemy = other.GetComponent<EnemyMovementBehavior>();

        // Halves the enemy's speed and increases the amount of points gained.
        if(enemy)
        {
            enemy.Speed = enemy.Speed / 2;
            ScoreCounterBehavior.Instance.IncreaseScore(150);
        }
    }
}
