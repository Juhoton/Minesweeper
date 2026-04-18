using System.Reflection.Emit;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class HighScoreMenu : MonoBehaviour
{
    [SerializeField] private Transform easyContainer;
    [SerializeField] private Transform mediumContainer;
    [SerializeField] private Transform hardContainer;
    [SerializeField] private GameObject m_ItemPrefab;

    private ScoreList scoreList;
    private SaveData saveData;

    private void Awake()
    {
        saveData = gameObject.GetComponent<SaveData>();
    }
    private void Start()
    {
        scoreList = saveData.Load();
        LoadScores();
    }

    public void LoadScores()
    {
        LoadView(DifficultySelection.GetSpecificDifficultyName(0), easyContainer);
        LoadView(DifficultySelection.GetSpecificDifficultyName(1), mediumContainer);
        LoadView(DifficultySelection.GetSpecificDifficultyName(2), hardContainer);
    }



    private void LoadView(string difficulty, Transform container)
    {
        List<Score> result = new List<Score>(scoreList.scores.FindAll(score => score.difficulty == difficulty));
        foreach (Score score in result)
        {
            var item_go = Instantiate(m_ItemPrefab);
            item_go.GetComponentInChildren<TextMeshProUGUI>().text = score.name + " " + score.time;
            item_go.transform.SetParent(container);
            item_go.transform.localScale = Vector2.one;
            Debug.Log("Added item" + score);
        }
        Debug.Log("Loaded" + difficulty + "Items");
    }
}
