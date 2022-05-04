using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovementBehavior : EnemyMovementBehavior
{
    [SerializeField]
    private float _moveDistance;
    private Vector3 _moveDirection;
    public override void Update()
    {
        if (transform.position.x <= -5)
            _moveDirection = new Vector3(1, 0, 0);
        else if (transform.position.x >= _moveDistance)
            _moveDirection = new Vector3(-1, 0, 0);

        Velocity = _moveDirection * Speed;
        base.Update();
    }
}
