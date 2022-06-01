using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : EnemyBehavior
{
    private float _teleportTime;
    private bool _isAttacking;
    private bool _isGoingLeft = false;

    private float _attackTimer = 0.0f;

    public override void Awake()
    {
        //SetCurrentAbility(new GhostAbility());
        PrepareNextAttack();
    }

    private void Update()
    {
        Target = GameManagerBehavior.Player;
        if(!_isAttacking)
        {
            transform.position = Vector3.Lerp(new Vector3(-5, 0, 5), new Vector3(5, 0, 5), (Mathf.Sin(2 * Time.time) / 2) + 0.5f);
            if(_isGoingLeft)
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Mathf.Sin(2 * Time.time));
            else
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Mathf.Cos(2 * Time.time));

            if (transform.position.x >= 5)
                _isGoingLeft = true;
            else if(transform.position.x <= -5)
                _isGoingLeft = false;
        }

        if(!GetComponent<HealthBehavior>().IsAlive)
            RoutineBehavior.Instance.StopAllTimedActions();
    }

    private void Vanish()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        _isAttacking = true;
        RoutineBehavior.Instance.StartNewTimedAction(arguments => Appear(), TimedActionCountType.SCALEDTIME, 1);
    }

    private void Appear()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z + 1);

        RoutineBehavior.Instance.StartNewTimedAction(arguments => Attack(), TimedActionCountType.SCALEDTIME, 0.5f);
        RoutineBehavior.Instance.StartNewTimedAction(arguments => PrepareNextAttack(), TimedActionCountType.SCALEDTIME, 1);
    }

    private void Attack()
    {
        if (transform)
        transform.GetChild(1).gameObject.SetActive(true);
    }


    private void PrepareNextAttack()
    {
        if (transform)
            transform.GetChild(1).gameObject.SetActive(false);
        _isAttacking = false;

        _teleportTime = Random.Range(50, 150);
        _teleportTime /= 10;
        RoutineBehavior.Instance.StartNewTimedAction(arguments => Vanish(), TimedActionCountType.SCALEDTIME, _teleportTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerMovementBehavior player = other.GetComponent<PlayerMovementBehavior>();

        if(player)
        {
            player.IsStunned = true;
            RoutineBehavior.Instance.StartNewTimedAction(arguments => player.IsStunned = false, TimedActionCountType.SCALEDTIME, 0.50f);
        }
    }
}
