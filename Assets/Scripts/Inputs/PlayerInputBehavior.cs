using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputBehavior : MonoBehaviour
{
    /// <summary>
    /// The behavior that allows the player to move.
    /// </summary>
    private PlayerMovementBehavior _playerMovement;

    // Start is called before the first frame update
    void Awake()
    {
        _playerMovement = GetComponent<PlayerMovementBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        // The player can only move on the x-axis.
        _playerMovement.MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0).normalized;
    }
}
