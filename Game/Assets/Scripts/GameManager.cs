using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GridManager gridM;
    [SerializeField] private TimeManager timeM;
    [SerializeField] private Canvas pause;
    [SerializeField] private Canvas gameOver;
    [SerializeField] private Canvas youWin;


    void Start()
    {
        gridM = GetComponentInChildren<GridManager>();

        StartEventListeners();

        pause.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        youWin.gameObject.SetActive(false);
    }

    // starts the event listener for win and lose condition
    // WIP Score update and win condition. Can't test win condition
    private void StartEventListeners()
    {
        gridM.mineExploded.AddListener(TriggerLoseCondition);
        gridM.tileCount.AddListener(CheckWinCondition);
    }

    private void CheckWinCondition(int tileCount)
    {
        if (tileCount == 0) TriggerWinCondition();
    }

    private void TriggerWinCondition()
    {
        Debug.Log("Mestarityötä! Voitit pelin");
        youWin.gameObject.SetActive(true);
    }

    //
    private void TriggerLoseCondition()
    {
        Debug.Log("BOOM!!! Hävisit pelin");

        timeM.StopTimer();
        gameOver.gameObject.SetActive(true);
    }

    // Resets the current scene
    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
