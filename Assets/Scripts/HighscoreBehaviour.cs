using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class HighscoreBehaviour : MonoBehaviour
{
    IDbConnection dbconn;

    public void SetHighscore(int score, string name)
    {
        dbconn = (IDbConnection)new SqliteConnection("URI=file:" + Application.dataPath + "/Database.db");
        dbconn.Open(); 

        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = $"Insert Into Highscore (Name,Score) Values('{name}',{score})";
        dbcmd.ExecuteNonQuery();

        //close Connection
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public List<HighscoreModel> GetHighscore()
    {
        var highscores = new List<HighscoreModel>();

        dbconn = (IDbConnection)new SqliteConnection("URI=file:" + Application.dataPath + "/Database.db");
        dbconn.Open();

        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = $"Select Name, Score From Highscore";

        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            highscores.Add(new HighscoreModel()
            {
                Name = reader.GetString(0),
                Score = reader.GetInt32(1)
            });
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;


        return highscores;
    }
}
