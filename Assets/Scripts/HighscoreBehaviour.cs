using System.Collections.Generic;
using UnityEngine;

public class HighscoreBehaviour : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("Highscorelist"))
            PlayerPrefs.SetString("Highscorelist", "{}");
    }

    public void SetHighscore(int score, string name)
    {
        var highscoreList = GetHighscore();


        highscoreList.Add(new HighscoreModel() { Name = name, Score = score });
        var highscoreListmodel = new HighscoreListModel() { HighscoreList = highscoreList };

        var listToJson = JsonUtility.ToJson(highscoreListmodel);
        PlayerPrefs.SetString("Highscorelist", listToJson);
        PlayerPrefs.Save();

    }

    public List<HighscoreModel> GetHighscore()
    {
        var list = PlayerPrefs.GetString("Highscorelist");
        Debug.Log("playerprefs list ist null");
        var result = JsonUtility.FromJson<HighscoreListModel>(list);
        Debug.Log("resultdingeslist ist null");


        if (result.HighscoreList == null)
            return new List<HighscoreModel>();

        return result.HighscoreList;
    }
}
