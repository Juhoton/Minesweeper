using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    bool isPaused = false;
    public static bool IsPaused { get; private set; } // Makes the paused state accessible from other scripts (?)


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        IsPaused = isPaused;

        Time.timeScale = isPaused ? 0f : 1f;
        pauseMenu.SetActive(isPaused);
        
        Debug.Log(isPaused ? "Game Paused" : "Game Resumed");
    }

    public void Resume()
    {
        Debug.Log("Resuming the game");
        TogglePause();
    }

    public void NewGame()
    {
        Debug.Log("Starting a new game");
        TogglePause();
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        Debug.Log("Going back to the main menu");
        TogglePause();
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Debug.Log("Quitting the game");
        Application.Quit();
    }
}
