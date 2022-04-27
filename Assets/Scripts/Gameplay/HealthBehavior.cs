using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour
{
    [SerializeField]
    private float _health;
    [SerializeField]
    private bool _isAlive;
    [SerializeField]
    private bool _destroyOnDeath;

    public float Health
    {
        get { return _health; }
    }

    public bool IsAlive
    {
        get { return _isAlive; }
    }

    public virtual void TakeDamage(float damageAmount)
    {
        _health -= damageAmount;
    }

    public virtual void OnDeath()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_health <= 0 && IsAlive)
            OnDeath();

        _isAlive = _health > 0;

        if (!IsAlive && _destroyOnDeath)
                Destroy(gameObject);
    }
}
