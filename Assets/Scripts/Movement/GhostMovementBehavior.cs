using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovementBehavior : EnemyMovementBehavior
{
    [SerializeField]
    private float _leftBoundry = 5;
    [SerializeField]
    private float _rightBoundry = 5;
    private Vector3 _moveDirection;

    public override void Update()
    {
        float distance = transform.position.z - Target.position.z;
        if (distance > 1)
        {
            if (transform.position.x <= _leftBoundry)
                _moveDirection = new Vector3(1, 0, -1);
            else if (transform.position.x >= _rightBoundry)
                _moveDirection = new Vector3(-1, 0, -1);
        }
        else
        {
            if (transform.position.x <= _leftBoundry)
                _moveDirection = new Vector3(1, 0, 0);
            else if (transform.position.x >= _rightBoundry)
                _moveDirection = new Vector3(-1, 0, 0);
            else if (transform.position.x >= _leftBoundry && transform.position.x <= _rightBoundry)
                _moveDirection = new Vector3(_moveDirection.x, 0, 0);
        }

        Velocity = _moveDirection * Speed;
        base.Update();
    }
}
