using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _velocity;
    [SerializeField]
    private float _moveSpeed = 1;

    public  bool IsStunned { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        _velocity = direction * _moveSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsStunned)
        {
            _velocity = Vector3.zero;
            return;
        }

        _rigidbody.MovePosition(transform.position + _velocity);
        if(transform.position.x > 5)
        {
            transform.position = new Vector3(5, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -5)
        {
            transform.position = new Vector3(-5, transform.position.y, transform.position.z);
        }
    }
}
