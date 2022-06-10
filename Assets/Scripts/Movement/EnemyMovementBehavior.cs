using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehavior : MovementBehavior
{
    [SerializeField]
    private float _speed;

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public override void Update()
    {
        //Speed is added to the movement here
        //Do not add Speed to enemies anywhere else
        Velocity *= Speed;
        base.Update();
    }
}