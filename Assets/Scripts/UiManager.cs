using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text _scoreText;
    public InputField nameInput;
    public GameObject _gameOverScreen;
    public Text _restartText;

    private int _score = 0;

    [SerializeField]
    private Image _currentLiveDisplay;

    [SerializeField]
    private Sprite[] _liveImages;

    private GameManager _gameManager;
    private HighscoreBehaviour _highscoreBehaviour;


    void Start()
    {
        _gameManager = GameObject.Find("MainGame").GetComponent<GameManager>();
        _highscoreBehaviour = new HighscoreBehaviour();

        UpdateScore(0);

        if (_gameManager == null)
            Debug.Log("Maingame is null and couldnt be found");
    }

    public void UpdateScore(int score)
    {
        _score = score;
        _scoreText.text = "Score: " + _score;
    }

    public void UpdateLives(int live)
    {
        _currentLiveDisplay.sprite = _liveImages[live];

        if (live == 0)
            GameOver();
    }

    public void SaveAndBackToMenu()
    {
        _highscoreBehaviour.SetHighscore(_score, nameInput.text);
        SceneManager.LoadScene(0);
    }

    public void SaveAndRestart()
    {
        _highscoreBehaviour.SetHighscore(_score, nameInput.text);
        SceneManager.LoadScene(1);
    }

    void GameOver()
    {
        _gameManager.SetGameOver();
        _gameOverScreen.SetActive(true);
    }
}
