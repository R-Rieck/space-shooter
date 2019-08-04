using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _gameOver = false;
    public GameObject PauseMenu;
    private bool isPaused = false;

    public Enemy _enemy;
    private SpawnBehaviour _spawnManager;

    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnBehaviour>();
        _enemy.SetMovementSpeed(1);
    }


    void Update()
    {
        GetPauseMenuActions();
    }

    void GetPauseMenuActions()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        isPaused = true;
    }

    public void SetGameOver()
    {
        _gameOver = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        isPaused = false;
    }

    public void IncreaseDifficulty()
    {
        _enemy.IncreaseMovementSpeed(0.5f);
        _spawnManager.IncreaseSpawnRate(0.1f);
    }

    public void Menu() => SceneManager.LoadScene(0);
    public void Quit() => Application.Quit();
}
