using UnityEngine;
using UnityEngine.SceneManagement;


public class DifficultyMenu : MonoBehaviour
{
    [SerializeField] private MainMenuManager mainMenuManager;

    private void Awake()
    {
        mainMenuManager = GameObject.FindWithTag("GameController").GetComponent<MainMenuManager>();
    }

    public void DifficultyEasy()
    {
        DifficultySelection.difficulty = 0;
        Debug.Log("Play with difficulty easy!");
        SceneManager.LoadScene("Game");
    }

    public void DifficultyMedium()
    {
        DifficultySelection.difficulty = 1;
        Debug.Log("Play with difficulty medium!");
        SceneManager.LoadScene("Game");
    }

    public void DifficultyHard()
    {
        DifficultySelection.difficulty = 2;
        Debug.Log("Play with difficulty hard!");
        SceneManager.LoadScene("Game");
    }

    public void Return()
    {
        Debug.Log("Returned to main menu");
        mainMenuManager.SetActiveCanvas(0);
    }
}
