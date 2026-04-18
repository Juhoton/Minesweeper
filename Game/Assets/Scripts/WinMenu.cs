using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TMP_InputField nameText;
    public Button saveScoreButton;
    public GameObject timerManager;
    private bool scoreSaved = false;

    void OnEnable()
    {
        timerText.GetComponent<TextMeshProUGUI>().text = timerManager.GetComponent<TimeManager>().timerText.text;
    }

    void Update()
    {
        if (!scoreSaved)
        {
            if (nameText.text.Length == 0)
            {
                saveScoreButton.interactable = false;
            }
            else
            {
                saveScoreButton.interactable = true;
            }
        }
    }

    public void SaveScore()
    {
        gameObject.GetComponent<SaveData>().Save(nameText.text, DifficultySelection.GetDifficultyName(), timerText.text);
        scoreSaved = true;
        nameText.interactable = false;
        saveScoreButton.interactable = false;
    }
}
