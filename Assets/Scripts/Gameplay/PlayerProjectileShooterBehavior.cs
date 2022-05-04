using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ability
{
    NONE,
    ZOMBIE,
    SKELETON
}

public class PlayerProjectileShooterBehavior : MonoBehaviour
{
    

    [SerializeField]
    private BulletBehavior _bulletRef;
    [SerializeField]
    private float _bulletForce;
    [SerializeField]
    private GameObject _owner;
    private float _delay = 0.3f;
    private float _delayTimer = 0;
    private float _fireButtonHeldTimer = 0;
    private float _chargeTimer = 1f;
    private Ability _currentAbility;
    [SerializeField]
    private GameObject _grabRadius;

    public Ability CurrentAbility
    {
        get { return _currentAbility; }
        set { _currentAbility = value; }
    }


    public void Fire()
    {
        if (_delayTimer >= _delay)
        {
            if (_fireButtonHeldTimer < _chargeTimer)
            {
                FireRight();
                Invoke("FireLeft", 0.25f);
            }
            else
                FireCharged();

            _delayTimer = 0;
        }
    }

    private void Update()
    {
        if(_delayTimer >= 0.1f)
        _grabRadius.SetActive(false);

        _delayTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            _fireButtonHeldTimer += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Fire();
            _fireButtonHeldTimer = 0;
        }
    }

    private void FireRight()
    {
        GameObject bullet = Instantiate(_bulletRef.gameObject, new Vector3(transform.position.x + 0.25f, transform.position.y, transform.position.z), transform.rotation);
        BulletBehavior bulletBehavior = bullet.GetComponent<BulletBehavior>();
        bulletBehavior.OwnerTag = _owner.tag;
        bulletBehavior.Rigidbody.AddForce(transform.forward * _bulletForce, ForceMode.Impulse);
    }
    private void FireLeft()
    {
        GameObject bullet = Instantiate(_bulletRef.gameObject, new Vector3(transform.position.x - 0.25f, transform.position.y, transform.position.z), transform.rotation);
        BulletBehavior bulletBehavior = bullet.GetComponent<BulletBehavior>();
        bulletBehavior.OwnerTag = _owner.tag;
        bulletBehavior.Rigidbody.AddForce(transform.forward * _bulletForce, ForceMode.Impulse);
    }
    private void FireCharged()
    {
        if(_currentAbility == Ability.NONE)
        {
            _grabRadius.SetActive(true);
        }
        else if(_currentAbility == Ability.ZOMBIE)
        {
            GameObject bullet = Instantiate(_bulletRef.gameObject, transform.position, transform.rotation);
            bullet.gameObject.transform.localScale *= 3;
            BulletBehavior bulletBehavior = bullet.GetComponent<BulletBehavior>();
            bulletBehavior.OwnerTag = _owner.tag;
            bulletBehavior.Rigidbody.AddForce(transform.forward * _bulletForce, ForceMode.Impulse);
            bulletBehavior.Damage *= 5;
        }
        else if(_currentAbility == Ability.SKELETON)
        {
            GameObject bullet = Instantiate(_bulletRef.gameObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            bullet.gameObject.transform.localScale = new Vector3(bullet.gameObject.transform.localScale.x * 3, bullet.gameObject.transform.localScale.y, bullet.gameObject.transform.localScale.z);
            BulletBehavior bulletBehavior = bullet.GetComponent<BulletBehavior>();
            bulletBehavior.DestroyOnHit = false;
            bulletBehavior.OwnerTag = _owner.tag;
            bulletBehavior.Rigidbody.AddForce(transform.forward * _bulletForce, ForceMode.Impulse);
            bulletBehavior.Damage *= 3;
        }
    }
}
