using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverCanvas;

    static private int score;

    void Start()
    {
        score = 0;
        scoreText.text = GetScoreText();
        gameOverCanvas.SetActive(true);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = GetScoreText();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private string GetScoreText() => $"Score: {score}";
}