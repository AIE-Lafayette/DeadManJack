using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : UseAbilityBehavior
{
    private EnemyMovementBehavior _movement;

    //The Enemy's target
    private GameObject _target;

    /// <summary>
    /// The amount of points the enemy will give the player when defeated.
    /// </summary>
    [SerializeField]
    private float _scoreAmount;

    public GameObject Target
    {
        get { return _target; }
        set { _target = value; }
    }

    public EnemyMovementBehavior Movement
    { 
        get { return _movement; } 
        set { _movement = value; }
    }

    public float ScoreAmount
    {
        get { return _scoreAmount; }
    }

    // Start is called before the first frame update
    public virtual void Awake()
    {
        _movement = GetComponent<EnemyMovementBehavior>();
        _target = GameManagerBehavior.Goal;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (_target == null)
        {
            _movement.Velocity = new Vector3(0, 0, 0);
            return;
        }

        //The distance of the enemy and the targets z-axis
        float distanceFromTarget = transform.position.z - Target.transform.position.z;

        //If the distance of the Target is greater than the approach distance, continue moving down on the z-axis
        if (distanceFromTarget > _movement.ApproachDistance)
            _movement.Velocity = new Vector3(0, 0, -1);
        else
            transform.LookAt(Target.transform);
            
    }

    public void SetCurrentAbility(Ability ability)
    {
        ability.VisualPrefab = CurrentAbility.VisualPrefab;
        CurrentAbility = ability;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
            return;

        else if (other.name == "Lose Zone")
            other.transform.parent.GetComponent<HealthBehavior>().TakeDamage(1);

        else if(other.name == "Heart")
            Destroy(gameObject);
    }
}
