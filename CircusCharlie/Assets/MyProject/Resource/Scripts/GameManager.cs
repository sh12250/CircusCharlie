using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text score;
    public TMP_Text bestScore;
    public TMP_Text bonus;
    public TMP_Text stage;
    public bool isGameOver = false;

    private int scoreNum = 0;
    private int bestScoreNum = 0;
    private int bonusNum = 5000;

    private float bonusReduceRate = 0.3f;
    private float time = 0;

    private void Awake()
    {
        if (!instance.IsValid())
        {
            instance = this;
        }
        else
        {
            GFunc.LogWarning("씬에 두개 이상의 게임 매니져가 존재합니다");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (bonusReduceRate <= time && bonusNum != 0)
        {
            time = 0;
            bonusNum -= 10;
            bonus.text = string.Format("Bonus : {0}", bonusNum);
        }
    }

    public void AddScore(int newScore)
    {
        if (!isGameOver)
        {
            scoreNum += newScore;
            score.text = string.Format("Score : {0}", scoreNum);
            if(scoreNum > bestScoreNum)
            {
                bestScoreNum = scoreNum;
                bestScore.text = string.Format("Best Score : {0}", bestScoreNum);
            }

        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
    }
}
