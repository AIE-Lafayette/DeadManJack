using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseBehavior : MonoBehaviour
{
    public bool IsPaused;
    public GameObject PauseUI;
    private PlayerFistBehavior playerFist;

    private void Awake()
    {
        playerFist = GetComponent<PlayerFistBehavior>();
    }

    public void TogglePause(InputAction.CallbackContext context)
    {
        if (!IsPaused)
        {
            Time.timeScale = 0;
            playerFist.CanShoot = false;
            PauseUI.SetActive(true);
            Debug.Log("Game Paused");
            IsPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            playerFist.CanShoot = true;
            PauseUI.SetActive(false);
            Debug.Log("Game Unpaused");
            IsPaused = false;
        }

    }
}
