using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehavior : MovementBehavior
{
    [SerializeField]
    private float _speed;

    //The distance that the enemy needs to be from the target before dynamically moving
    [SerializeField]
    private float _approachDistance;

    private Ability _currentAbility;

    public Ability CurrentAbility
    {
        get { return _currentAbility; }
    }
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public float ApproachDistance
    {
        get { return _approachDistance; }
    }

    public override void Update()
    {
        //Speed is added to the movement here
        //Do not add Speed to enemies anywhere else
        Velocity *= Speed;
        base.Update();
    }

    /// <summary>
    /// Determines what happens when the enemy is grabbed by the player.
    /// </summary>
    public virtual void OnBeingGrabbed(PlayerFistBehavior player)
    {

    }
}
