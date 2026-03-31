using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GridManager gridM;


    void Start()
    {
        gridM = GetComponentInChildren<GridManager>();

        StartEventListeners();
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
        ResetGame();
    }

    //
    private void TriggerLoseCondition()
    {
        Debug.Log("BOOM!!! Hävisit pelin");
        ResetGame();
    }

    // Resets the current scene
    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
