using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private GameManagerBehavior _gameManager;
    private EnemyMovementBehavior _movement;

    //The Enemy's target
    private Transform _target;
    public Transform Target
    {
        get { return _target; }
        set { _target = value; }
    }

    public EnemyMovementBehavior Movement
    { 
        get { return _movement; } 
    }


    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<EnemyMovementBehavior>();
        _target = _gameManager.Goal.transform;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //The distance of the enemy and the targets z-axis
        float distanceFromTarget = transform.position.z - Target.position.z;

        //If the distance of the Target is greater than the approach distance, continue moving down on the z-axis
        if (distanceFromTarget > _movement.ApproachDistance)
            _movement.Velocity = new Vector3(0, 0, -1);
        else
            transform.LookAt(Target);
    }

    /// <summary>
    /// Determines what happens when the enemy is grabbed by the player.
    /// </summary>
    public virtual void OnBeingGrabbed(PlayerFistBehavior player)
    {

    }
}