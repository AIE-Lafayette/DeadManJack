using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHeadBehavior : EnemyBehavior
{
    [SerializeField]
    private SkeletonBehavior _body;
    private bool _isGrounded = false;
    private HealthBehavior _health;

    // Start is called before the first frame update
    public override void Awake()
    {
        _health = GetComponent<HealthBehavior>();
        GameManager = _body.GameManager;
        base.Awake();
        SetCurrentAbility(new BonemerangAbility());
    }

    // Update is called once per frame
    public override void Update()
    {
        float distanceFromTarget = transform.position.z - Target.transform.position.z;
        Vector3 direction = Target.transform.position - transform.position;
        direction = direction.normalized;
        if (distanceFromTarget > Movement.ApproachDistance)
        {
            if (_isGrounded)
            {
                Movement.Velocity = new Vector3(0, 5f, -1);
            }
            else
            {
                Movement.Velocity = new Vector3(0, 0, -1);
            }
        }
        else
        {
            if (_isGrounded)
            {
                Movement.Velocity = new Vector3(direction.x, 5f, direction.z);
            }
            else
            {
                Movement.Velocity = new Vector3(direction.x, 0, direction.z);
            }
        }


        if(!_health.IsAlive)
        {
            Destroy(_body.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Plane")
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == "Plane")
        {
            _isGrounded = false;
        }
    }
}
