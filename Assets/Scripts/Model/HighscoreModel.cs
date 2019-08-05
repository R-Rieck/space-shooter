using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class HighscoreModel
{
    public string Name;
    public int Score;
}

[System.Serializable]
public class HighscoreListModel
{
    public List<HighscoreModel> HighscoreList;
}