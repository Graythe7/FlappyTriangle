using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;

    private int score;
    public TMP_Text scoreText;
    public TextMeshProUGUI recordScoreText; 
    private int recordScore;

    public GameObject startButton;
    public GameObject restartButton;

    public TMP_Text gameOverText;

    private void Awake()
    {
        Pause();   
    }

    private void Start()
    {
        // Load the saved record score (if any) or set to 0
        recordScore = PlayerPrefs.GetInt("RecordScore", 0);
        UpdateRecordScoreUI();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        startButton.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void RestartGame()
    {
        //This line of code is used to reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void CheckForNewRecord(int currentScore)
    {
        if (currentScore > recordScore)
        {
            recordScore = currentScore;

            // Save the new record score
            PlayerPrefs.SetInt("RecordScore", recordScore);
            PlayerPrefs.Save();

            UpdateRecordScoreUI();
        }
    }

    private void UpdateRecordScoreUI()
    {
        recordScoreText.text = "Record: " + recordScore;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        Pause();
    }
}
