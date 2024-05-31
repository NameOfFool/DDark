using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvas;

    private bool isPaused;

    private void Start()
    {
        _mainMenuCanvas.SetActive(false);
    }
    private void Update()
    {
        if(InputManager.instance.MenuToggleInput)
        {
            if(!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;

        OpenMainMenu();
    }
    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1;

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
}
