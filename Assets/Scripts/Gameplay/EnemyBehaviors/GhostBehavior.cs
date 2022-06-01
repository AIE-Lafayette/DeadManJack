using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : EnemyBehavior
{
    private float _teleportTime;
    private bool _isAttacking;
    private bool _isGoingLeft = false;

    public override void Awake()
    {
        //SetCurrentAbility(new GhostAbility());
        _teleportTime = Random.Range(50, 150);
        _teleportTime /= 10;
        RoutineBehavior.Instance.StartNewTimedAction(arguments => Vanish(), TimedActionCountType.SCALEDTIME, _teleportTime);
    }

    private void Update()
    {
        Target = GameManagerBehavior.Player;
        if(!_isAttacking)
        {
            transform.position = Vector3.Lerp(new Vector3(-5, 0, 15), new Vector3(5, 0, 15), (Mathf.Sin(2 * Time.time) / 2) + 0.5f);
            if(_isGoingLeft)
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Mathf.Sin(2 * Time.time));
            else
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Mathf.Cos(2 * Time.time));

            if (transform.position.x >= 5)
                _isGoingLeft = true;
            else if(transform.position.x <= -5)
                _isGoingLeft = false;
        }
    }

    private void Vanish()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        
        RoutineBehavior.Instance.StartNewTimedAction(arguments => Appear(), TimedActionCountType.SCALEDTIME, 1);
    }

    private void Appear()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z + 1);
        _isAttacking = true;

        RoutineBehavior.Instance.StartNewTimedAction(arguments => transform.GetChild(1).gameObject.SetActive(true) , TimedActionCountType.SCALEDTIME, 0.25f);
        RoutineBehavior.Instance.StartNewTimedAction(arguments => transform.GetChild(1).gameObject.SetActive(false) , TimedActionCountType.SCALEDTIME, 0.5f);
        RoutineBehavior.Instance.StartNewTimedAction(arguments => PrepareNextAttack(), TimedActionCountType.SCALEDTIME, 1);
    }

    private void PrepareNextAttack()
    {
        _isAttacking = false;
        _teleportTime = Random.Range(5, 15);
        _teleportTime /= 10;
        RoutineBehavior.Instance.StartNewTimedAction(arguments => Vanish(), TimedActionCountType.SCALEDTIME, _teleportTime);
    }
}
