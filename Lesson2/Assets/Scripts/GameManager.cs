using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float time = 40;
    public TextMeshProUGUI timerText;
    public Text scoreText;
    public GameObject player;
    public GameObject gameWonCanvas;
    public GameObject gameOverCanvas;

    static private int score;

    void Start()
    {
        score = 0;
        scoreText.text = GetScoreText();
        gameWonCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    void Update()
    {
        if (player.activeSelf == true)
        {
            UpdateTimer();
        }
        if (IsGameLost())
        {
            GameLost();
        }
    }

    public void GameWon()
    {
        player.SetActive(false);
        gameWonCanvas.SetActive(true);
    }

    public void GameLost()
    {
        player.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = GetScoreText();
    }

    public void AddTime(int amount)
    {
        time += amount;
        timerText.text = GetTimerText();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private bool IsGameLost()
    {
        return time <= 0 ||
            player.transform.position.y < -10;
    }

    private void UpdateTimer()
    {
        time -= Time.deltaTime;
        timerText.text = GetTimerText();
    }

    private string GetScoreText() => $"Score: {score}";
    private string GetTimerText() => $"Time: {Math.Ceiling(time)}";
}