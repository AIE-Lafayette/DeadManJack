using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : UseAbilityBehavior
{
    [SerializeField]
    private GameManagerBehavior _gameManager;
    private EnemyMovementBehavior _movement;

    //The Enemy's target
    private GameObject _target;

    private Ability _currentAbility;

    public Ability CurrentAbility
    {
        get { return _currentAbility; }
    }

    public GameObject Target
    {
        get { return _target; }
        set { _target = value; }
    }

    public EnemyMovementBehavior Movement
    { 
        get { return _movement; } 
    }

    public GameManagerBehavior GameManager
    {
        get { return _gameManager; }
        set { _gameManager = value; }
    }


    // Start is called before the first frame update
    public virtual void Awake()
    {
        _movement = GetComponent<EnemyMovementBehavior>();
        _target = _gameManager.Goal;
    }

    // Update is called once per frame
    public virtual void Update()
    {
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
        _currentAbility = ability;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Heart")
            return;

        HealthBehavior health = other.GetComponent<HealthBehavior>();

        if (!health)
            return;

        health.TakeDamage(1);

        if (GetComponent<HealthBehavior>().DestroyOnDeath)
            Destroy(gameObject);
    }
}
