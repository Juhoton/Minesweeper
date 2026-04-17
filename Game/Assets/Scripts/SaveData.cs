using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{

    private string path;

    void Awake()
    {
        path = Application.persistentDataPath + "/Scores.json";
    }

    public void Save(string name, string difficulty, string time)
    {
        ScoreList scoreList = Load();

        Score newScore = new Score
        {
            name = name,
            difficulty = difficulty,
            time = time
        };
        scoreList.scores.Add(newScore);

        List<Score> sortedScores = SortScore(scoreList.scores);

        if (sortedScores.FindAll(score => score.difficulty == difficulty).Count > 10)
        {
            int count = 0;
            foreach (Score score in sortedScores)
            {
                if (score.difficulty == difficulty)
                {
                    count++;
                }
                if (count == 10)
                {
                    sortedScores.Remove(score);
                }
            }
        }

        scoreList.scores = sortedScores;

        string json = JsonUtility.ToJson(scoreList);
        File.WriteAllText(path, json);
    }

    private List<Score> SortScore(List<Score> scoreList)
    {
        scoreList.Sort((a, b) =>
        {
            int ToSeconds(string t)
            {
                var parts = t.Split(':');
                return int.Parse(parts[0]) * 60 + int.Parse(parts[1]);
            }

            return ToSeconds(a.time).CompareTo(ToSeconds(b.time));
        });
        return scoreList;
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
    public string time;
}
