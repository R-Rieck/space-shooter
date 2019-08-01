using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text _scoreText;

    public Text _gameOverScreen;
    public Text _restartText;

    private int _score = 0;

    [SerializeField]
    private Image _currentLiveDisplay;

    [SerializeField]
    private Sprite[] _liveImages;

    private MainGame _mainGame;

    void Start()
    {
        _mainGame = GameObject.Find("MainGame").GetComponent<MainGame>();

        UpdateScore(0);

        if (_mainGame == null)
            Debug.Log("Maingame is null and couldnt be found");
    }

    public void UpdateScore (int score) => _scoreText.text = "Score: " + score;

    public void UpdateLives (int live)
    {
        _currentLiveDisplay.sprite = _liveImages[live];

        if (live == 0)
            GameOver();
    }

    void GameOver()
    {
        _mainGame.SetGameOver();
        _restartText.gameObject.SetActive(true);
        StartCoroutine(FlickerGameOverText());
    }

    IEnumerator FlickerGameOverText()
    {
        
        while (true)
        {
            _gameOverScreen.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            _gameOverScreen.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.2f);
        }
        
    }
}
