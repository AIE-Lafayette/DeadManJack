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
    /// The player's fist behavior.
    /// </summary>
    [SerializeField]
    private PlayerFistBehavior _playerFist;

    /// <summary>
    /// The animator for the player.
    /// </summary>
    [SerializeField]
    private Animator _animator;

    private void Start()
    {
        _playerFist.OnShoot += PlayPunchAnimation;
        _playerFist.OnGrapple += PlayGrabAnimation;
    }

    private void Update()
    {
        // The velocity of the player.
        Vector3 playerVelocity = _playerMovement.Velocity;

        // Checks to see if the player is standing still or moving.
        _animator.SetFloat("XDirection", (playerVelocity.normalized).x);
    }

    /// <summary>
    /// Plays one of the two punch animations based on which fist was used.
    /// </summary>
    /// <param name="didPunchRight"> Checks to see which fist shot. </param>
    public void PlayPunchAnimation(bool didPunchRight)
    {
        if (didPunchRight)
            _animator.SetTrigger("PunchRight");
        else
            _animator.SetTrigger("PunchLeft");
    }

    public void PlayGrabAnimation()
    {
        _animator.SetTrigger("Grab");
    }

    public void PlayVictoryAnimation()
    {
        _animator.SetTrigger("BeatWave");
    }
}
