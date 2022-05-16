using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehavior : EnemyBehavior
{
    [SerializeField]
    private GameObject _head;
    private HealthBehavior _health;

    private void Start()
    {
        _health = GetComponent<HealthBehavior>();
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
                transform.LookAt(Target);
        }
        else
        {
            GameObject spawnedEnemy = Instantiate(_head, transform.position, transform.rotation);
        }
    }

    public override void OnBeingGrabbed(PlayerFistBehavior player)
    {
        if (!player)
            return;
    }
}
