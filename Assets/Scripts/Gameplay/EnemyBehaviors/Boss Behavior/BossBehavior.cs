using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : EnemyBehavior
{
    public enum State
    {
        IDLE,
        MOVE,
        SUMMONENEMY,
        ABILITY,
    }

    /// <summary>
    /// The time the boss has been doing this action
    /// </summary>
    private float _actionTime = 0;

    /// <summary>
    /// The Boss's current state
    /// </summary>
    private State _currentState;

    private State _lastState;

    public override void Awake()
    {
        _currentState = State.IDLE;
        base.Awake();
        Target = GameManagerBehavior.Player;
    }

    public virtual void Move() { }

    public virtual void Summon() { }

    public virtual void Ability() { }

    private void Update()
    {
        _currentState = DecisionMaking();

        switch (_currentState)
        {
            case State.IDLE:
                Movement.Velocity = Vector3.zero;
                break;

            case State.MOVE:
                Move();
                break;

            case State.SUMMONENEMY:
                Summon();
                break;

            case State.ABILITY:
                Ability();
                break;
        }

        _actionTime += Time.deltaTime;
        _lastState = _currentState;

        if (_currentState != _lastState)
            _actionTime = 0;
    }

    private State DecisionMaking()
    {
        //A random number for determining the state
        int stateRNG = Random.Range(0, 100);

        //If the last state of the enemy was summoning an enemy or using an ability, go idle for a few seconds
        if (_currentState == State.SUMMONENEMY || _currentState == State.ABILITY)
            return State.IDLE;

        //If idle for over 2 seconds, choose a random state to go to
        else if(_currentState == State.IDLE && _actionTime > 2)
        {
            if (stateRNG > 75)
                return State.ABILITY;
            else if (stateRNG > 50)
                return State.SUMMONENEMY;
            else
                return State.MOVE;
        }

        //If the boss is currently moving, check to see if the boss should continue moving
        else if(_currentState == State.MOVE)
            if (stateRNG < 70 - _actionTime || _actionTime < 5)
                return State.MOVE;

        //Check to see if the boss should summon an enemy, based on the number of enemies currently on screen
        else if (stateRNG >= GameManagerBehavior.EnemyCount * 20)
            return State.SUMMONENEMY;

        //If the player is close horizontally to the boss, it would use an ability
        else if(Target.transform.position.x - transform.position.x < 5)
        {
            MovementBehavior player = Target.GetComponent<MovementBehavior>();
            if (Target.transform.position.x > transform.position.x && player.Velocity.x < 0)
                return State.ABILITY;
            else if (Target.transform.position.x < transform.position.x && player.Velocity.x > 0)
                return State.ABILITY;
        }
        
        //The enemy would move more the lower health it has
        else if (stateRNG > 50 - GetComponent<HealthBehavior>().Health)
            return State.MOVE;

        //If nothing else applies, just return idle
        return State.IDLE;
    }
}