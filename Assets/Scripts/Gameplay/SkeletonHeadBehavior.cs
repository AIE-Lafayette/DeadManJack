using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHeadBehavior : EnemyBehavior
{
    private bool _isGrounded = false;
    private HealthBehavior _health;

    // Start is called before the first frame update
    public override void Start()
    {
        _health = GetComponent<HealthBehavior>();
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if(_isGrounded)
        {
            Movement.Velocity = new Vector3(0, 5f, -1);
        }
        else
        {
            Movement.Velocity = new Vector3(0, 0, -1);
        }

        if(!_health.IsAlive)
        {
            Destroy(transform.parent.gameObject);
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
