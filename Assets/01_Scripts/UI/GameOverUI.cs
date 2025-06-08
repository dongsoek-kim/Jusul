using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    public Button restartbutton;
    public Canvas playerCanvas;

    private void Awake()
    {
        restartbutton.onClick.AddListener(RestartGame);
    }

    public void OnEnable()
    {
        playerCanvas.gameObject.SetActive(false);
    }
    private void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
