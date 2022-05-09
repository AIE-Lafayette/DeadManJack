using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ability
{
    NONE,
    ZOMBIE,
    SKELETON
}

public class PlayerProjectileShooterBehavior : BulletEmitterBehavior
{
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

    public override void Fire()
    {
        if (_delayTimer >= _delay)
        {
            if (_fireButtonHeldTimer < _chargeTimer)
            {
                transform.position = new Vector3(1, 0, 0);
                BaseFire();
                transform.position = new Vector3(-1, 0, 0);
                Invoke("BaseFire", 0.25f);
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

    /// <summary>
    /// Calls the base fire function from the BulletEmmitterBehavior
    /// </summary>
    private void BaseFire()
    {
        base.Fire();
    }

    private void FireCharged()
    {
        if(_currentAbility == Ability.NONE)
        {
            _grabRadius.SetActive(true);
        }
        else if(_currentAbility == Ability.ZOMBIE)
        {

        }
        else if(_currentAbility == Ability.SKELETON)
        {

        }
    }
}
