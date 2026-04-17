using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MainMenuManager mainMenuManager;

    private void Awake()
    {
        mainMenuManager = GameObject.FindWithTag("GameController").GetComponent<MainMenuManager>();
    }

    public void PlayGame()
    {
        Debug.Log("Play!");
        mainMenuManager.SetActiveCanvas(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
