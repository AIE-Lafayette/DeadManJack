using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehavior : EnemyBehavior
{
    [SerializeField]
    private SkeletonHeadBehavior _head;
    [SerializeField]
    private Transform _body = null;
    private bool _headSpawned = false;

    private HealthBehavior _health;

    public override void Awake()
    {
        _health = GetComponent<HealthBehavior>();
        base.Awake();
        SetCurrentAbility(new FireProjectileAbility());
        CurrentAbility.SetUses(1);
    }

    public override void Update()
    {
        base.Update();

        if(_health.IsAlive)
            Movement.Velocity = new Vector3(0, 0, -1);

        if (!_head)
            Destroy(gameObject);
    }

    /// <summary>
    /// The skeleton's way to split the head from the body.
    /// </summary>
    public void SplitHead()
    {
        if (_headSpawned || !_head)
            return;

        _head.HeadModel.SetActive(true);
        Movement.Velocity = Vector3.zero;
        _head.GetComponent<Rigidbody>().isKinematic = false;
        _head.GetComponent<EnemyMovementBehavior>().Speed = 3;
        _head.transform.SetParent(transform);
        _headSpawned = true;
        
    }
}
