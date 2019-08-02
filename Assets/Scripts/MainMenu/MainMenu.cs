using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start() => _gameManager = new GameManager(); 
    public void StartGame() => SceneManager.LoadScene(1);
    public void Options() => SceneManager.LoadScene(3);
    public void Highscores() => SceneManager.LoadScene(2);
    public void QuitGame() => Application.Quit();
}
