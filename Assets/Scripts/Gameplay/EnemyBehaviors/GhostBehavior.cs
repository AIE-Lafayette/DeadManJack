using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : EnemyBehavior
{
    private float _teleportTime;
    private float _teleportTimer = 0.0f;

    private float _vanishTime = 2;
    private float _vanishTimer = 0.0f;

    private bool _vanished = false;

    public override void Awake()
    {
        base.Awake();
        //SetCurrentAbility(new GhostAbility());
        _teleportTime = Random.Range(5, 15);
    }

    private void Update()
    {
        Target = GameManagerBehavior.Player;
        if(transform.position.x <= -5)
            Movement.Velocity = new Vector3(1, 0, 0);
        if(transform.position.x >= 5)
            Movement.Velocity = new Vector3(-1, 0, 0);
        Movement.Velocity = Movement.Velocity.normalized;

        if(_teleportTimer > _teleportTime)
        {
            _vanished = true;
            _teleportTimer = 0;
        }
        if (_vanishTimer > _vanishTime)
        {
            _vanished = false;
            _vanishTimer = 0;
            transform.position = Target.transform.position + Vector3.forward;
        }

        if (_vanished)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            _vanishTimer += Time.deltaTime;
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            _teleportTimer += Time.deltaTime;
        }

    }
}
