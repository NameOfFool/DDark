using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    private UIDocument _mainMenu;
    [SerializeField] private InputReader m_inputReader;

    private bool isPaused = false;

    private void Start()
    {
        _mainMenu = GetComponent<UIDocument>();
    }

    public void PauseToggle()
    {
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
        _mainMenu.enabled = true;
    }
    public void CloseAllMenus()
    {
        _mainMenu.enabled = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    
}
