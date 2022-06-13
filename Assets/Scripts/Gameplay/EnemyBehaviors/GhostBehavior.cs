using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : EnemyBehavior
{
    // The delegates that will set up the times when the ghost will hide and scare.
    public delegate void SetHide();
    public delegate void SetScare();
    public SetHide HideAnimation;
    public SetScare ScareAnimation;

    //The time before the ghost vanishes to move to the player
    private float _teleportTime;

    //Bools used to change the Ghost's behavior
    private bool _isTargetingHeart; //The ghost rushes the heart
    private bool _isAttacking; //The ghost tries to attack the player

    //The number of attacks the ghost performed, used to change behavior
    private float _numberOfAttacksPerformed = 0;

    //The health for the ghost
    private HealthBehavior _health;

    public override void Awake()
    {
        SetCurrentAbility(new FireProjectileAbility());
        PrepareNextAttack();
        _health = GetComponent<HealthBehavior>();
        _health.IsInvulnerable = true;
        base.Awake();
    }

    public override void Update()
    {
        //A reoccuring null check. This is for when the ghost dies
        if (!this)
            return;

        Target = GameManagerBehavior.Player;

        //The ghost should lerp from side to side around the middle of runway while not attacking
        if(!_isAttacking && _numberOfAttacksPerformed < 3)
        {
            transform.position = Vector3.Lerp(new Vector3(-5, 0, 0), new Vector3(5, 0, 0), (Mathf.Sin(2 * Time.time) / 2) + 0.5f);
        }
        //If the ghost has attacked 2 or more times
        else if (_numberOfAttacksPerformed >= 3)
        {
            //The ghost lerps like before, but further back in the runway
            if(!_isTargetingHeart)
                transform.position = Vector3.Lerp(new Vector3(-5, 0, 15), new Vector3(5, 0, 15), (Mathf.Sin(2 * Time.time) / 2) + 0.5f);

            Target = GameManagerBehavior.Goal;

            //When the ghost is ready to target the heart, it should rush the heart and move to evade incoming attacks
            if (_isTargetingHeart)
            {
                Movement.Velocity = Target.transform.position - transform.position;
                Movement.Velocity = new Vector3(Movement.Velocity.x + Mathf.Cos(Time.time * 5) * 2, Movement.Velocity.y, Movement.Velocity.z);
            }
        }
    }

    private void Vanish()
    {
        HideAnimation.Invoke();

        if(this != null)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            _isAttacking = true;
            RoutineBehavior.Instance.StartNewTimedAction(arguments => Appear(), TimedActionCountType.SCALEDTIME, 1);
        }
    }

    private void Appear()
    {
        if (!this)
            return;

        transform.GetChild(0).gameObject.SetActive(true);
        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z + 0.75f);

        ScareAnimation.Invoke();

        RoutineBehavior.Instance.StartNewTimedAction(arguments => _health.IsInvulnerable = false, TimedActionCountType.SCALEDTIME, 0.40f);
        RoutineBehavior.Instance.StartNewTimedAction(arguments => Attack(), TimedActionCountType.SCALEDTIME, 0.5f);
        RoutineBehavior.Instance.StartNewTimedAction(arguments => _health.IsInvulnerable = true, TimedActionCountType.SCALEDTIME, 0.75f);
        RoutineBehavior.Instance.StartNewTimedAction(arguments => PrepareNextAttack(), TimedActionCountType.SCALEDTIME, 1);
    }

    private void Attack()
    {
        if (this != null)
            transform.GetChild(1).gameObject.SetActive(true);
        _isAttacking = true;
    }


    private void PrepareNextAttack()
    {
        if (!this)
            return;

        transform.GetChild(1).gameObject.SetActive(false);
        _isAttacking = false;

        _teleportTime = Random.Range(50, 150);
        _teleportTime /= 10;
        _numberOfAttacksPerformed++;
        if (_numberOfAttacksPerformed < 3)
            RoutineBehavior.Instance.StartNewTimedAction(arguments => Vanish(), TimedActionCountType.SCALEDTIME, _teleportTime);
        else
        {
            _health.IsInvulnerable = false;
            RoutineBehavior.Instance.StartNewTimedAction(arguments => _isTargetingHeart = true, TimedActionCountType.SCALEDTIME, _teleportTime / 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isTargetingHeart)
            base.OnTriggerEnter(other);

        if (!other.CompareTag("Player"))
            return;

        PlayerMovementBehavior player = other.GetComponent<PlayerMovementBehavior>();

        if(player)
        {
            if(transform.GetChild(1).gameObject.activeInHierarchy)
            player.IsStunned = true;
            RoutineBehavior.Instance.StartNewTimedAction(arguments => player.IsStunned = false, TimedActionCountType.SCALEDTIME, 0.75f);
        }
    }
}
