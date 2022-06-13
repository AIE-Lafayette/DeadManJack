using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _health;
    [SerializeField]
    private bool _destroyOnDeath;
    [SerializeField]
    private bool _isAlive = true;
    private bool _isInvulnerable = false;

    public float Health
    {
        get { return _health; }
    }

    public bool IsAlive
    {
        get { return _isAlive; }
    }

    public bool DestroyOnDeath
    {
        get { return _destroyOnDeath; }
    }

    public bool IsInvulnerable
    { 
        get { return _isInvulnerable; }
        set { _isInvulnerable = value; }
    }


    private void Awake()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        //If the object is still alive, but has less than zero health, call the on Death function
        if (_health <= 0 && IsAlive)
            OnDeath();
    }

    /// <summary>
    /// Inflicts damage to the object
    /// </summary>
    /// <param name="damageToTake">The amount of damage inflicted</param>
    public void TakeDamage(float damageToTake)
    {
        if(!IsInvulnerable)
            _health -= damageToTake;
    }

    /// <summary>
    /// Heals the object
    /// </summary>
    /// <param name="damageToHeal">The amount of damage to heal</param>
    public void HealDamage(float damageToHeal)
    {
        _health += damageToHeal;

        if (_health > _maxHealth)
            _health = _maxHealth;
    }

    /// <summary>
    /// Determines what happens to the object when it dies
    /// </summary>
    private void OnDeath()
    {
        _isAlive = false;

        EnemyBehavior enemy = GetComponent<EnemyBehavior>();
        
        if (enemy)
        {
            ScoreCounterBehavior.Instance.IncreaseScore(enemy.ScoreAmount);

            // If the enemy is not a skeleton or a ghost...
            if(!enemy.GetComponent<SkeletonBehavior>() && !enemy.GetComponent<GhostBehavior>())
            {
                // ...decrease the enemy count and attempt to set its death timer so its animation can play.
                GameManagerBehavior.EnemyCount--;
                if(_destroyOnDeath)
                    RoutineBehavior.Instance.StartNewTimedAction(arguments => Destroy(gameObject), TimedActionCountType.SCALEDTIME, 1f);
                enemy.Target = null;
                return;
            }
            // If it is a skeleton...
            else if (enemy.GetComponent<SkeletonBehavior>())
            {
                // ...sets the timer for the head to split from the body.
                RoutineBehavior.Instance.StartNewTimedAction(arguments => (enemy as SkeletonBehavior).SplitHead(), TimedActionCountType.SCALEDTIME, 0.5f);
                enemy.Target = null;
                return;
            }
            else if(enemy.GetComponent<GhostBehavior>())
                GameManagerBehavior.EnemyCount--;
        }

        //If the object should be destroyed on death, destroy the game object
        if (_destroyOnDeath)
            Destroy(gameObject);
            
    }
}
