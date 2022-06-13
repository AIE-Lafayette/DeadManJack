using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHeadBehavior : EnemyBehavior
{
    [SerializeField]
    private SkeletonBehavior _body;
    private bool _isGrounded = false;
    private HealthBehavior _health;

    /// <summary>
    /// The visualization of the head.
    /// </summary>
    [SerializeField]
    private GameObject _headModel;

    public GameObject HeadModel { get { return _headModel; } }

    // Start is called before the first frame update
    public override void Awake()
    {
        _health = GetComponent<HealthBehavior>();
        Target = GameManagerBehavior.Goal;
        base.Awake();
        SetCurrentAbility(new FireProjectileAbility());
        CurrentAbility.SetUses(1);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (_isGrounded)
        {
            Movement.Velocity = new Vector3(0, 5f, -1);
        }
        else
        {
            Movement.Velocity = new Vector3(0, 0, -1);
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
