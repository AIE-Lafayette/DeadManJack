using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimationBehavior : MonoBehaviour
{
    /// <summary>
    /// The zombie's health behavior, so it can tell when it dies.
    /// </summary>
    [SerializeField]
    private HealthBehavior _health;

    [SerializeField]
    private EnemyMovementBehavior _movement;

    /// <summary>
    /// The animator for the zombie.
    /// </summary>
    [SerializeField]
    private Animator _animator;

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("IsAlive", _health.IsAlive);
        _animator.SetFloat("Speed", _movement.Speed);
    }
}
