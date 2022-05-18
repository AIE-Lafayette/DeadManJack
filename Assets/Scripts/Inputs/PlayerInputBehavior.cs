using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputBehavior : MonoBehaviour
{
    /// <summary>
    /// The controller that sets the inputs that the player can use.
    /// </summary>
    private PlayerController _playerController;

    /// <summary>
    /// The behavior that allows the player to move.
    /// </summary>
    private PlayerMovementBehavior _playerMovement;

    /// <summary>
    /// The fists of the player that allow them to attack.
    /// </summary>
    private PlayerFistBehavior _playerFists;

    /// <summary>
    /// Checks whether or not the player can grab or use an ability.
    /// </summary>
    private bool _playerCanGrab;

    private void Awake()
    {
        _playerController = new PlayerController();
        _playerMovement = GetComponent<PlayerMovementBehavior>();
        _playerFists = GetComponent<PlayerFistBehavior>();
    }

    private void OnEnable()
    {
        _playerController.Enable();
    }

    private void OnDisable()
    {
        _playerController.Disable();
    }

    private void Start()
    {
        _playerController.DeadManJack.Shoot.started += context => _playerFists.Punch(context);
        _playerController.DeadManJack.ChargeAbility.started += context => _playerFists.Activate();
        _playerController.DeadManJack.QuitGame.started += context => Application.Quit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveDirection = _playerController.DeadManJack.Movement.ReadValue<Vector2>();
        _playerMovement.Move(moveDirection);
    }
}
