using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFistBehavior : MonoBehaviour
{
    /// <summary>
    /// The first fist the player character will shoot from.
    /// </summary>
    [SerializeField]
    private BulletEmitterBehavior _rightFist;

    /// <summary>
    /// The second fist the player character will shoot from.
    /// </summary>
    [SerializeField]
    private BulletEmitterBehavior _leftFist;

    /// <summary>
    /// The player's ability to grab enemies.
    /// </summary>
    private GrappleBehavior _playerGrapple;

    /// <summary>
    /// Checks to see which fist is currently active for the user.
    /// </summary>
    private bool _currentFistRight = true;

    private bool _canShoot = true;

    /// <summary>
    /// The player's current ability.
    /// </summary>
    private UseAbilityBehavior _currentPlayerAbility;

    public BulletEmitterBehavior RightFist
    {
        get { return _rightFist; }
        set { _rightFist = value; }
    }

    /// <summary>
    /// The player's current ability.
    /// </summary>
    public UseAbilityBehavior CurrentPlayerAbility
    {
        get { return _currentPlayerAbility; }
    }

    public GrappleBehavior PlayerGrapple
    {
        get { return _playerGrapple; }
    }

    public void ToggleShoot()
    {
        if (_canShoot)
            _canShoot = false;
        else
            _canShoot = true;
    }

    /// <summary>
    /// The ability for the player to throw hands at enemies. Swaps which hand after firing a projectile.
    /// </summary>
    public void Punch(InputAction.CallbackContext context)
    {
        // If the current fist is the right one...
        if (_currentFistRight && _canShoot)
        {
            // ...shoot and swap to the left.
            _rightFist.Fire();
            _currentFistRight = false;
            ToggleShoot();
            RoutineBehavior.Instance.StartNewTimedAction(arguments => ToggleShoot(), TimedActionCountType.SCALEDTIME, 0.35f);
        }
        // If the current fist is the left one...
        else if (_canShoot)
        {
            // ...shoot and swap to the right.
            _leftFist.Fire();
            _currentFistRight = true;
            ToggleShoot();
            RoutineBehavior.Instance.StartNewTimedAction(arguments => ToggleShoot(), TimedActionCountType.SCALEDTIME, 0.35f);
        }
    }

    public void Activate()
    {
        if (CurrentPlayerAbility.CurrentAbility == null)
            PlayerGrapple.Activate();
        else if (CurrentPlayerAbility.CurrentAbility != null && _canShoot)
        {
            CurrentPlayerAbility.CurrentAbility.Activate();
            ToggleShoot();
            RoutineBehavior.Instance.StartNewTimedAction(arguments => ToggleShoot(), TimedActionCountType.SCALEDTIME, 0.35f);
        }
            
    }

    private void Start()
    {
        // Sets up the new grapple ability and gives it the player's grab radius.
        _playerGrapple = GetComponentInChildren<GrappleBehavior>();

        _currentPlayerAbility = GetComponent<UseAbilityBehavior>();

        // Sets the current ability to null so that the player can use the grab immediately.
        _currentPlayerAbility.CurrentAbility = null;
    }
}
