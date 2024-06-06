using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvas;

    private bool isPaused = false;

    private void Start()
    {
        _mainMenuCanvas.SetActive(false);
    }

    public void PauseToggle(InputAction.CallbackContext context)
    {
        if (context.started)
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
    }
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;

        InputManager.PlayerInput.SwitchCurrentActionMap("UI");
        OpenMainMenu();
    }
    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1;
        InputManager.PlayerInput.SwitchCurrentActionMap("Player");

        CloseAllMenus();
    }
    public void OpenMainMenu()
    {
        _mainMenuCanvas.SetActive(true);
    }
    public void CloseAllMenus()
    {
        _mainMenuCanvas.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("!!!");
    }
}
