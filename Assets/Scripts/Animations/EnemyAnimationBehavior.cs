using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationBehavior : MonoBehaviour
{
    /// <summary>
    /// The enemy's health behavior, so it can tell when it dies.
    /// </summary>
    [SerializeField]
    private HealthBehavior _health;

    [SerializeField]
    private EnemyMovementBehavior _movement;

    /// <summary>
    /// The animator for the enemy.
    /// </summary>
    [SerializeField]
    private Animator _animator;

    public HealthBehavior Health { get { return _health; } }

    public EnemyMovementBehavior Movement { get { return _movement; } }

    public Animator Animator { get { return _animator; } }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (_animator == null)
            return;

        _animator.SetBool("IsAlive", _health.IsAlive);
        _animator.SetFloat("Speed", _movement.Speed);
    }
}
