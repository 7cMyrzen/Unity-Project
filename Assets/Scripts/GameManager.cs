using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;

    private int _score = 0;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void AddScore(int amount)
    {
        _score += amount;
        scoreText.text = _score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        finalScoreText.text = "Score final : " + _score.ToString();
        gameOverPanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }

    public void Restart()
    {
        _score = 0;
        gameOverPanel.SetActive(false);
        scoreText.gameObject.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}