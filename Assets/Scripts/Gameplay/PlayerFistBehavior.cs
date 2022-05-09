using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ability
{
    NONE,
    ZOMBIE,
    SKELETON
}

public class PlayerFistBehavior : MonoBehaviour
{
    /// <summary>
    /// The first fist the player character will shoot from.
    /// </summary>
    [SerializeField]
    BulletEmitterBehavior _rightFist;

    /// <summary>
    /// The second fist the player character will shoot from.
    /// </summary>
    [SerializeField]
    BulletEmitterBehavior _leftFist;

    /// <summary>
    /// The basic bullet that the player can shoot.
    /// </summary>
    [SerializeField]
    BulletBehavior _basicBulletRef;

    /// <summary>
    /// The bullet the player can shoot when they have absorbed a zombie.
    /// </summary>
    [SerializeField]
    BulletBehavior _zombieChargeShotRef;

    /// <summary>
    /// The ability that the player currently holds.
    /// </summary>
    private Ability _currentAbility;

    /// <summary>
    /// The area that the player's grapple will work in.
    /// </summary>
    [SerializeField]
    private GameObject _grabRadius;

    /// <summary>
    /// The amount of time between the shots a player can take.
    /// </summary>
    private float _shotDelay = 0.25f;

    /// <summary>
    /// The current amount of time between shots compared to how long it should take for the player to shoot again.
    /// </summary>
    private float _shotDelayTimer = 0.25f;

    /// <summary>
    /// The time between when the fists should shoot.
    /// </summary>
    private float _secondShotDelay = 0.2f;

    /// <summary>
    /// The current amount of time from when the first fist shot and when the second will shoot.
    /// </summary>
    private float _secondShotDelayTimer = 0;

    /// <summary>
    /// The boolean that determines whether or not the second shot is charging.
    /// </summary>
    private bool _secondShotIncoming = false;

    /// <summary>
    /// The amount of time necessary for the charge shot to fire.
    /// </summary>
    private float _chargeShotDelay = 0.75f;

    /// <summary>
    /// The amount of time necessary to get to the charge shot.
    /// </summary>
    private float _chargeShotTimer;

    public Ability CurrentAbility
    {
        get { return _currentAbility; }
        set { _currentAbility = value; }
    }

    private void Update()
    {
        // Once the delay timer is past the point of the delay...
        if (_secondShotDelayTimer >= _secondShotDelay)
        {
            // ...the second shot is fired and the shot, the timer is set to zero and it stops charging.
            _leftFist.Fire();
            _secondShotDelayTimer = 0;
            _secondShotIncoming = false;
        }

        // If the second shot is charging, it will add delta time to the delay timer.
        if (_secondShotIncoming)
            _secondShotDelayTimer += Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.Space) && _chargeShotTimer >= _chargeShotDelay && CurrentAbility == Ability.NONE)
        {
            
        }
        // If the player lifts up the key after pressing space and the delay timer is past a certain point...
        else if (Input.GetKeyUp(KeyCode.Space) && _shotDelayTimer >= _shotDelay)
        {
            // ...the player will fire the first shot. The delay timer will be set to zero and the second shot will begin charging.
            _rightFist.Fire();
            _shotDelayTimer = 0;
            _secondShotIncoming = true;
        }
        // If the timer is less than the delay add delta time to the timer.
        else if (_shotDelayTimer < _shotDelay)
            _shotDelayTimer += Time.deltaTime;


    }
}
