using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private Vector3 _velocity;

    private bool _useScaledMovement = true;

    public bool UseScaledMovement
    { 
        get { return _useScaledMovement; }
        set { _useScaledMovement = value; }
    }

    public Vector3 Velocity
    { 
        get { return _velocity; }
        set { _velocity = value;
               Vector3.ClampMagnitude(_velocity, 100.0f); }
    }

    public virtual void Update()
    {
        if (_useScaledMovement)
            transform.position += Velocity * Time.deltaTime;
        else if (!_useScaledMovement)
            transform.position += Velocity * Time.unscaledDeltaTime;
    }
}
