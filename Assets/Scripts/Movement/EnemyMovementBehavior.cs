using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehavior : MovementBehavior
{
    [SerializeField]
    private GameManagerBehavior _gameManager;

    //The Enemy's target
    [SerializeField]
    private Transform _target;

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

    public override void Update()
    {
        //The distance of the enemy and the targets z-axis
        float distanceFromTarget = transform.position.z - Target.position.z;

        //If the distance of the Target is greater than the approach distance, continue moving down on the z-axis
        if(distanceFromTarget > _approachDistance)
            Velocity = new Vector3(0, 0, -1);
        else
            transform.LookAt(Target);

        //Speed is added to the movement here
        //Do not add Speed to enemies anywhere else
        Velocity *= Speed;
        base.Update();
    }

    public void SetCurrentAbility(Ability ability)
    {
        _currentAbility = ability;
    }

    /// <summary>
    /// Determines what happens when the enemy is grabbed by the player.
    /// </summary>
    public virtual void OnBeingGrabbed(PlayerFistBehavior player)
    {

    }
}
