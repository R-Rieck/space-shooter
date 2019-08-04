using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    Transform _tableDataContainer;
    Transform _tableData;
    HighscoreBehaviour _data = new HighscoreBehaviour();

    void Start()
    {
        _tableData = GameObject.Find("TableData").GetComponent<RectTransform>();
        _tableDataContainer = GameObject.Find("TableDataContainer").GetComponent<RectTransform>();
        _tableDataContainer.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -50);

        InitData(_data.GetHighscore().OrderByDescending(x => x.Score).ToList());
        _tableData.gameObject.SetActive(false);
    }

    void InitData(List<HighscoreModel> data)
    {
        float templateHeight = 45f;

        for (int i = 0; i < data.Count && i < 10; i++)
        {
            var dataContainer = Instantiate(_tableData, _tableDataContainer);

            var pos = dataContainer.Find("POS").GetComponent<Text>();
            pos.text = (i + 1).ToString();
            var score = dataContainer.Find("SCORE").GetComponent<Text>();
            score.text = data[i].Score.ToString();
            var name= dataContainer.Find("NAME").GetComponent<Text>();
            name.text = data[i].Name;

            var dataContainerRect = dataContainer.GetComponent<RectTransform>();
            dataContainerRect.anchoredPosition = new Vector2(0, -templateHeight * i);
        }
    }
}
