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
    BulletEmitterBehavior _rightFist;

    /// <summary>
    /// The second fist the player character will shoot from.
    /// </summary>
    [SerializeField]
    BulletEmitterBehavior _leftFist;

    /// <summary>
    /// The area that the player's grapple will work in.
    /// </summary>
    [SerializeField]
    private GameObject _grabRadius;

    private GrappleAbilityBehavior playerGrapple;

    /// <summary>
    /// Checks to see which fist is currently active for the user.
    /// </summary>
    private bool _currentFistRight = true;

    /// <summary>
    /// The player's current ability.
    /// </summary>
    private UseAbilityBehavior _currentPlayerAbility;

    /// <summary>
    /// The player's current ability.
    /// </summary>
    public UseAbilityBehavior CurrentPlayerAbility
    {
        get { return _currentPlayerAbility; }
    }

    /// <summary>
    /// The ability for the player to throw hands at enemies. Swaps which hand after firing a projectile.
    /// </summary>
    public void Punch(InputAction.CallbackContext context)
    {
        // If the current fist is the right one...
        if (_currentFistRight)
        {
            // ...shoot and swap to the left.
            _rightFist.Fire();
            _currentFistRight = false;
        }
        // If the current fist is the left one...
        else
        {
            // ...shoot and swap to the right.
            _leftFist.Fire();
            _currentFistRight = true;
        }
    }

    private void Start()
    {
        // Sets up the new grapple ability and gives it the player's grab radius.
        GrappleAbilityBehavior playerGrapple = new GrappleAbilityBehavior();
        playerGrapple.GrabRadius = _grabRadius;

        _currentPlayerAbility = GetComponent<UseAbilityBehavior>();

        // Sets the player's current ability to be the player's grapple.
        _currentPlayerAbility.CurrentAbility = playerGrapple;
    }
}
