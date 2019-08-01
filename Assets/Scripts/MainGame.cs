using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    private bool _gameOver = false;
    public GameObject PauseMenu;
    private bool isPaused = false;

    void Update()
    {
        GetPauseMenuActions();
        if (_gameOver && Input.GetKey(KeyCode.F))
            SceneManager.LoadScene(1);
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

    public void Menu() => SceneManager.LoadScene(0);
    public void Quit() => Application.Quit();
}
