using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : UseAbilityBehavior
{
    private EnemyMovementBehavior _movement;

    /// <summary>
    /// The Enemy's Target
    /// </summary>
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

    public virtual void Awake()
    {
        _movement = GetComponent<EnemyMovementBehavior>();
        _target = GameManagerBehavior.Goal;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //Enemy should not move if it does not have a target. Mainly used for death animations
        if (_target == null)
        {
            _movement.Velocity = new Vector3(0, 0, 0);
            return;
        }

        //The base movement directions for enemies, should be overriten in the specific behaviors
        _movement.Velocity = new Vector3(0, 0, -1);
    }

    public void SetCurrentAbility(Ability ability)
    {
        ability.VisualPrefab = CurrentAbility.VisualPrefab;
        CurrentAbility = ability;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
            return;

        else if (other.name == "Lose Zone")
            other.transform.parent.GetComponent<HealthBehavior>().TakeDamage(1);

        else if(other.name == "Heart")
            Destroy(gameObject);
    }
}
