using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehavior : EnemyBehavior
{
    [SerializeField]
    private GameObject _head;
    [SerializeField]
    private Transform _body = null;
    private bool _headSpawned = false;

    private HealthBehavior _health;

    public override void Start()
    {
        _health = GetComponent<HealthBehavior>();
        base.Start();
    }

    public override void Update()
    {
        if(_health.IsAlive)
        {
            //The distance of the enemy and the targets z-axis
            float distanceFromTarget = transform.position.z - Target.position.z;

            //If the distance of the Target is greater than the approach distance, continue moving down on the z-axis
            if (distanceFromTarget > Movement.ApproachDistance)
                Movement.Velocity = new Vector3(0, 0, -1);
            else
            {
                Movement.Velocity = Vector3.zero;
                transform.LookAt(Target);
            }
        }
        else
        {
            Movement.Velocity = Vector3.zero;
            if(_body.rotation.eulerAngles.x < 80)
                _body.Rotate(Time.deltaTime * 100, 0, 0);
            if (_body.position.y > 0.1)
                _body.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, transform.position.z);
            if(!_headSpawned)
            {
                _head.GetComponent<Rigidbody>().isKinematic = false;
                _head.GetComponent<EnemyMovementBehavior>().Speed = Movement.Speed;
            }
        }
    }

    public override void OnBeingGrabbed(PlayerFistBehavior player)
    {
        if (!player)
            return;
    }
}
