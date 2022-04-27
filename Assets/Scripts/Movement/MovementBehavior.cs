using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private Vector3 _velocity;

    /// <summary>
    /// The Speed and Direction of the object
    /// </summary>
    public Vector3 Velocity
    { 
        get { return _velocity; }
        set { _velocity = value;
               Vector3.ClampMagnitude(_velocity, 100.0f); }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        transform.position += Velocity * Time.deltaTime;
    }
}
