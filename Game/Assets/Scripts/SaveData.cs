using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{

    private string path;

    void Awake()
    {
        path = Application.persistentDataPath + "/Scores.json";
        Save("Lime", "medium", 11);
        Debug.Log(Load().scores[0].difficulty);
    }

    public void Save(string name, string difficulty, int time)
    {
        ScoreList scoreList = Load();

        Score newScore = new Score
        {
            name = name,
            difficulty = difficulty,
            time = time
        };
        scoreList.scores.Add(newScore);

        string json = JsonUtility.ToJson(scoreList);
        File.WriteAllText(path, json);

        Debug.Log(newScore);
    }

    public ScoreList Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<ScoreList>(json);
        }
        else
        {
            return new ScoreList();
        }
    }
}

[System.Serializable]
public class ScoreList
{
    public List<Score> scores = new List<Score>();
}
[System.Serializable]
public class Score
{
    public string name;
    public string difficulty;
    public int time;
}