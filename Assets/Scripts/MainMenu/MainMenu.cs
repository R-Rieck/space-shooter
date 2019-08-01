using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private MainGame _mainGameFunctionalities;

    void Start(){
        _mainGameFunctionalities = new MainGame();
    }
    public void StartGame() => SceneManager.LoadScene(1);
    public void Options() => SceneManager.LoadScene(3);
    public void Highscores() => SceneManager.LoadScene(2);
    public void QuitGame() => Application.Quit();
}
