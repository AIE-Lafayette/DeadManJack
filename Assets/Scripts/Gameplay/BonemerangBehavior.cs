using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonemerangBehavior : BulletBehavior
{
    /// <summary>
    /// The distance the bonemerang will travel before returning to its owner.
    /// </summary>
    [SerializeField]
    private float _distance;

    /// <summary>
    /// The position of the character that fired the bonemerang.
    /// </summary>
    private Vector3 _startingPosition;

    /// <summary>
    /// The check to see if the bonemerang should begin heading towards its owner.
    /// </summary>
    private bool _movingToOwner = false;

    // Update is called once per frame
    void Update()
    {
        if (_startingPosition == null)
            _startingPosition = Owner.transform.position;

        if (_startingPosition.z + transform.position.z >= _distance)
            _movingToOwner = true;

        // Clamps the y position.
        if (transform.position.y != _startingPosition.y)
            transform.SetPositionAndRotation(new Vector3(transform.position.x, _startingPosition.y, transform.position.z), transform.rotation);

        if (_movingToOwner)
        {
            Rigidbody.AddForce((Owner.transform.position - transform.position).normalized * 5, ForceMode.Impulse);
            _movingToOwner = false;
        }
            
        base.Update();
    }
}
