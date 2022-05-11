using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    /// The area that the player's grapple will work in.
    /// </summary>
    [SerializeField]
    private GameObject _grabRadius;

    private bool _currentFistRight = true;

    /// <summary>
    /// The ability that the player currently holds.
    /// </summary>
    private Ability _currentAbility;

    public Ability CurrentAbility
    {
        get { return _currentAbility; }
        set { _currentAbility = value; }
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

    private void Update()
    {
        
    }
}
