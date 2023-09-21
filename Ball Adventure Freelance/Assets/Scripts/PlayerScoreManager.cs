using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerScoreManager : MonoBehaviour
{
    [SerializeField] float runScore;
    [SerializeField] TextMeshProUGUI scoreText, highScoreText;
    [SerializeField] PlayerDeathManager playerDeathManager;
    private bool playerDied;
    private SaveManager saveManager;
    private LevelDataSO currentLevelData;

    private void Start()
    {
        playerDeathManager.onDeath += UpdateScore;
        saveManager = SaveManager.instance;
        currentLevelData = saveManager.GetCurrentLevelData();
    }


    private void Update()
    {
        if (!playerDied) runScore += Time.deltaTime * 10;
        scoreText.text = ((int)runScore).ToString();
    }

    public void UpdateScore()
    {
        playerDied = true;
        if (runScore > currentLevelData.highscore) currentLevelData.highscore = (int)runScore;
        highScoreText.text = $"High Score - {currentLevelData.highscore}";
    }

}
