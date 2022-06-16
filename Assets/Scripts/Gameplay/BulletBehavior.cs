using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private GameObject _owner;
    private string _ownerTag;
    [SerializeField]
    private float _lifeTime;
    private float _currentLifeTime;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private bool _destroyOnHit;
    [SerializeField]
    private Sprite _abilitySprite;

    /// <summary>
    /// The particle system for the bullet that will play on hit.
    /// </summary>
    [SerializeField]
    private ParticleSystem _particleSystem;

    public GameObject Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }

    public string OwnerTag
    { 
        get { return _ownerTag; }
        set { _ownerTag = value; }
    }

    public Rigidbody Rigidbody
    {
        get { return _rigidbody; }
    }

    public Sprite AbilitySprite
    {
        get { return _abilitySprite; }
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


    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        RoutineBehavior.Instance.StartNewTimedAction(arguments => DestroyBullet(), TimedActionCountType.SCALEDTIME, _lifeTime);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == null)
            return;

        HealthBehavior otherHealth = other.GetComponent<HealthBehavior>();
        if (!otherHealth)
            return;

        if (!otherHealth.IsAlive)
            return;

        if (other.CompareTag(OwnerTag))
            return;

        otherHealth.TakeDamage(_damage);

        Instantiate(_particleSystem, transform.position, Quaternion.identity);

        if (_destroyOnHit)
            Destroy(gameObject);
    }
    
    private void DestroyBullet()
    {
        if (this != null)
            Destroy(gameObject);
    }
}
