using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBehavior : MonoBehaviour
{
    /// <summary>
    /// The player's movement behavior.
    /// </summary>
    [SerializeField]
    private PlayerMovementBehavior _playerMovement;

    /// <summary>
    /// The animator for the player.
    /// </summary>
    [SerializeField]
    private Animator _animator;

    private void Awake()
    {
        
    }

    private void Update()
    {
        // Checks to see if the player is standing still or moving.
        _animator.SetFloat("XDirection", _playerMovement.Velocity.x);
    }
}
