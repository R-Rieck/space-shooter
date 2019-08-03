using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighscoreBehaviour : MonoBehaviour
{
    private string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "sshs.json";

    public void SetHighscore(int score, string name)
    {
        //var highscoreList = GetHighscores();

        //highscoreList.Add(new HighscoreModel { Name = name, Score = score });

        var obj = new HighscoreModel() { Name = name, Score = score };
        var highscoreListToString = JsonUtility.ToJson(obj);

        File.WriteAllText(path, highscoreListToString);
    }

    public List<HighscoreModel> GetHighscores()
    {
        var scores = File.ReadAllText(path);

        var scoreToJsonArray = JsonUtility.FromJson<HighscoreModel>(scores);

        return new List<HighscoreModel>(); ;
    }
}
