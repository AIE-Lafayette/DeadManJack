using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehavior : MovementBehavior
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damage;

    public Transform Target
    {
        get { return _target; }
        set { _target = value; }
    }

    public float Speed
    { 
        get { return _speed; }
        set { _speed = value; }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _target)
        {
            //Increment
            HealthBehavior health = other.GetComponent<HealthBehavior>();
            if (health)
                health.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
