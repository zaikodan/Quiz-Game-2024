
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowManager : MonoBehaviour
{
    static public WindowManager instance;

    [SerializeField] 
    private GameObject gameOverWindow;

    [SerializeField] 
    TextMeshProUGUI scoreText, finalScoreText, recordText;

    public TextMeshProUGUI ScoreText { get => scoreText; }
    public TextMeshProUGUI FinalScoreText { get => finalScoreText; }
    public TextMeshProUGUI RecordText { get => recordText; }
    public GameObject GameOverWindow { get => gameOverWindow; }

    private void Awake()
    {
        instance = this;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Jogo");
        Time.timeScale = 1;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
}
