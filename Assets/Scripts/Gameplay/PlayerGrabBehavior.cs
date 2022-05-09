using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabBehavior : MonoBehaviour
{
    private PlayerProjectileShooterBehavior _playerProjectile;

    void Awake()
    {
        _playerProjectile = transform.parent.GetChild(0).GetComponent<PlayerProjectileShooterBehavior>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
            return;

        if (!_playerProjectile)
            return;

        if (_playerProjectile.CurrentAbility != Ability.NONE)
            return;

        other.GetComponent<EnemyMovementBehavior>().OnBeingGrabbed(_playerProjectile);
    }
}
