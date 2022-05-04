using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;
    private Vector3 _rotationDirection;
    [SerializeField]
    private float _maxDistance;

    public Vector3 MoveDirection
    {
        get { return _moveDirection; }
        set { _moveDirection = value; }
    }

    public Vector3 RotationDirection
    {
        get { return _rotationDirection; }
        set { _rotationDirection = value; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _maxDistance += transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Moves the Player
        Vector3 velocity = MoveDirection * _speed * Time.fixedDeltaTime;

        RotationDirection = velocity.normalized;
        velocity += transform.position;

        //If the object's new position would be within the bound...
        if (velocity.z < _maxDistance)
        {
            //...Translate the object
            transform.Translate(MoveDirection * _speed * Time.fixedDeltaTime);
        }

            //If the object would go beyond the bounds...
        else if (velocity.z < _maxDistance)
        {
            //Set the objects x to be the minimum distance
            transform.position = new Vector3(transform.position.x, transform.position.y, _maxDistance);
        }
    }
}
