using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GridManager gridM;
    [SerializeField] private TimeManager timeM;
    [SerializeField] private Canvas pause;
    [SerializeField] private Canvas gameOver;
    [SerializeField] private Canvas youWin;

    [SerializeField] private int selectedDifficulty = 0; //0 = easy, 1 = medium, 2 = hard
    [SerializeField] private int gridSizeEasy = 10;
    [SerializeField] private int mineCountEasy = 20;

    [SerializeField] private int gridSizeMedium = 16;
    [SerializeField] private int mineCountMedium = 52;

    [SerializeField] private int gridSizeHard = 24;
    [SerializeField] private int mineCountHard = 116;


    void Awake()
    {
        gridM = GetComponentInChildren<GridManager>();
        AdjustDifficulty();

        StartEventListeners();

        pause.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        youWin.gameObject.SetActive(false);
    }

    public void SetDifficulty(int newDifficulty)
    {
        selectedDifficulty = newDifficulty;
    }

    private void AdjustDifficulty()
    {
        SetDifficulty(DifficultySelection.difficulty);
        switch (selectedDifficulty)
        {
            case 0:
                gridM.SetGridSize(gridSizeEasy);
                gridM.SetMineCount(mineCountEasy);
                break;
            case 1:
                gridM.SetGridSize(gridSizeMedium);
                gridM.SetMineCount(mineCountMedium);
                break;
            case 2:
                gridM.SetGridSize(gridSizeHard);
                gridM.SetMineCount(mineCountHard);
                break;
        }
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

        PauseMenu.IsPaused = true;
        timeM.StopTimer();
        youWin.gameObject.SetActive(true);
    }

    //
    private void TriggerLoseCondition()
    {
        Debug.Log("BOOM!!! Hävisit pelin");

        PauseMenu.IsPaused = true;
        timeM.StopTimer();
        gameOver.gameObject.SetActive(true);
    }

    // Resets the current scene
    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
