using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovementBehavior : EnemyMovementBehavior
{
    private float _moveTimer = 0.0f;
    private bool _wasHit = false;
    public override void Update()
    {
        if (!_wasHit)
            Velocity = new Vector3(0, 0, -1);
        else
        {
            if(transform.position.x > 0)
                Velocity = new Vector3(-1, 0, 0);
            else
                Velocity = new Vector3(1, 0, 0);
            _moveTimer += Time.deltaTime;

            if(_moveTimer > 1)
            {
                _wasHit = false;
                _moveTimer = 0;
            }
        }

        base.Update();
    }

    public override void OnBeingGrabbed(PlayerFistBehavior player)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _wasHit = true;
        _moveTimer = 0.0f;
    }
}
