using System.Reflection.Emit;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class HighScoreMenu : MonoBehaviour
{
    private ScoreList scoreList;
    private ScrollView easyScoreView;

    private void Awake()
    {
        scoreList = gameObject.GetComponent<SaveData>().Load();
        easyScoreView = gameObject.GetComponentInChildren<ScrollView>();
    }
    public void LoadScores()
    {
        LoadView(easyScoreView, DifficultySelection.GetSpecificDifficultyName(0));

    }



    private void LoadView(ScrollView scrollView, string difficulty)
    {
        List<Score> result = new List<Score>(scoreList.scores.FindAll(score => score.difficulty == difficulty));
        foreach (Score score in result)
        {
            scrollView.Add(new UnityEngine.UIElements.Label(score.name + " " + score.time));
        }
    }
}
