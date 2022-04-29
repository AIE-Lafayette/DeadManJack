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

    /// <summary>
    /// How far the enemy can be from the player before attacking.
    /// </summary>
    [SerializeField]
    private float _seekDistance;

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


    private void Awake()
    {
        _seekDistance += Target.transform.position.z;
    }

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
