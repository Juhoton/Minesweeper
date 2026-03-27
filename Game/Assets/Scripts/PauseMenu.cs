using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pauseMenu.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // check if already paused, if so resume, otherwise pause
            if (isPaused)
            {
                // unpause the game
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
            else
            {
                // pause the game
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }

        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
