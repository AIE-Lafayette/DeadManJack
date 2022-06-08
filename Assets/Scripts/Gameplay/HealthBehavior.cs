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
        Debug.Log("On Death");
        _isAlive = false;

        EnemyBehavior enemy = GetComponent<EnemyBehavior>();
        
        if (enemy)
        {
            ScoreCounterBehavior.Instance.IncreaseScore(enemy.ScoreAmount);

            SkeletonBehavior skeleton = GetComponent<SkeletonBehavior>();
            if(!skeleton)
                GameManagerBehavior.EnemyCount--;

            RoutineBehavior.Instance.StartNewTimedAction(arguments => Destroy(gameObject), TimedActionCountType.SCALEDTIME, 1f);
            enemy.Target = null;
            return;
        }

        //If the object should be destroyed on death, destroy the game object
        if (_destroyOnDeath)
            Destroy(gameObject);
            
    }
}
