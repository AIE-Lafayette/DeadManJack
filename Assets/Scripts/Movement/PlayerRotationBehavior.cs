using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationBehavior : MonoBehaviour
{
    private Vector3 _rotationDirection;

    // Update is called once per frame
    void Update()
    {
        _rotationDirection = transform.parent.GetComponent<PlayerMovementBehavior>().RotationDirection;
        if(_rotationDirection.magnitude != 0)
        transform.forward = _rotationDirection;

        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(0, Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(0, -Time.deltaTime, 0);
    }
}
