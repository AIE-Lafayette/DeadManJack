using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private string _ownerTag;
    [SerializeField]
    private float _lifeTime;
    private float _currentLifeTime;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private bool _destroyOnHit;

    public string OwnerTag
    { 
        get { return _ownerTag; }
        set { _ownerTag = value; }
    }

    public Rigidbody Rigidbody
    {
        get { return _rigidbody; }
    }

    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public bool DestroyOnHit
    { 
        get { return _destroyOnHit; }
        set { _destroyOnHit = value; }
    }
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(OwnerTag))
            return;

        HealthBehavior otherHealth = other.GetComponent<HealthBehavior>();
        if (!otherHealth)
            return;

        if (other.name != "Ghost")
            otherHealth.TakeDamage(_damage);

        if (_destroyOnHit)
            Destroy(gameObject);
    }

    private void Update()
    {
        _currentLifeTime += Time.deltaTime;

        if (_currentLifeTime >= _lifeTime)
            Destroy(gameObject);
    }
}
