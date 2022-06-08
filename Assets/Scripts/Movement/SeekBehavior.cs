using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehavior : MonoBehaviour
{
    /// <summary>
    /// The transform that the character will seek.
    /// </summary>
    private Transform _target;

    /// <summary>
    /// The transform of the character.
    /// </summary>
    private Rigidbody _rigidbody;

    private Vector3 _startingPosition;

    /// <summary>
    /// The transform that the character will seek.
    /// </summary>
    public Transform Target
    {
        get { return _target; }
        set { _target = value; }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward * 3, ForceMode.Impulse);
        _startingPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (transform.position.y != _startingPosition.y)
            transform.SetPositionAndRotation(new Vector3(transform.position.x, _startingPosition.y, transform.position.z), new Quaternion());

        if (_target == null)
            return;

        Vector3 directionToTarget = _target.position - transform.position;

        Vector3 desiredVelocity = directionToTarget.normalized * 7;

        _rigidbody.AddForce(desiredVelocity, ForceMode.Acceleration);
    }
}
