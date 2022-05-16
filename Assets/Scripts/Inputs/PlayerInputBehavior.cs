using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputBehavior : MonoBehaviour
{
    private PlayerController _playerController;
    private PlayerMovementBehavior _playerMovement;
    private PlayerFistBehavior _playerFists;

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
        _playerController.DeadManJack.ChargeAbility.performed += context => _playerFists.CurrentPlayerAbility.ActivateAbility();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveDirection = _playerController.DeadManJack.Movement.ReadValue<Vector2>();
        _playerMovement.Move(moveDirection);
    }
}
