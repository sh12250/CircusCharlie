using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject bG_L;
    public GameObject bG_M;
    public GameObject bG_R;

    public GameObject fP_L;
    public GameObject fP_R;

    public GameObject stageStartUi;
    public GameObject gameOverUi;

    public TMP_Text score;
    public TMP_Text bestScore;
    public TMP_Text bonus;
    public TMP_Text stage;
    public TMP_Text life;
    public bool isPlayerDead = false;
    public bool isGameOver = false;

    public GameData gameData;
    public int bonusNum = 5000;

    private float bonusReduceRate = 0.5f;
    private float stageWait = 3f;
    private float gameOver = 5f;
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
        Time.timeScale = 0f;
        bestScore.text = string.Format("Best : {0 :00000}", gameData.bestScore_Stage1);
        life.text = string.Format("Life {0}", gameData.life);
    }

    void Update()
    {
        if (gameData.life == 0)
        {
            gameOverUi.SetActive(true);

        }

        if (gameOver <= time && gameOverUi.activeInHierarchy)
        {
            GameOver();
        }

        if (isPlayerDead)
        {
            StopObjects();
            RingSpawner rS = FindObjectOfType<RingSpawner>();
            rS.enabled = false;

            RingController rCon1 = rS.rings[0].GetComponent<RingController>();
            rCon1.enabled = false;
            RingController rCon2 = rS.rings[1].GetComponent<RingController>();
            rCon2.enabled = false;
            RingController rCon3 = rS.rings[2].GetComponent<RingController>();
            rCon3.enabled = false;
            RingController rCon4 = rS.rings[3].GetComponent<RingController>();
            rCon4.enabled = false;
            RingController rCon5 = rS.rings[4].GetComponent<RingController>();
            rCon5.enabled = false;
        }

        if (Time.timeScale == 0f)
        {
            time += Time.unscaledDeltaTime;
        }
        else if (Time.timeScale == 1f)
        {
            time += Time.deltaTime;
        }

        if (stageWait <= time && isPlayerDead)
        {
            time = 0f;
            gameData.life -= 1;
            GFunc.LoadScene("StageScene");
        }

        if (stageWait <= time && stageStartUi.activeInHierarchy)
        {
            gameData.score_Stage1 = 0;

            time = 0f;
            stageStartUi.SetActive(false);
            Time.timeScale = 1f;
        }

        if (bonusReduceRate <= time && bonusNum != 0 && !stageStartUi.activeInHierarchy && !isPlayerDead)
        {
            time = 0;
            bonusNum -= 10;
        }

        bonus.text = string.Format("Bonus : {0}", bonusNum);

        PlayerController pCon = FindObjectOfType<PlayerController>();
        if (pCon.detect == 16)
        {
            StopObjects();

            RingSpawner rS = FindObjectOfType<RingSpawner>();
            rS.enabled = false;

            RingController rCon1 = rS.rings[0].GetComponent<RingController>();
            rCon1.speed = 0;
            RingController rCon2 = rS.rings[1].GetComponent<RingController>();
            rCon2.speed = 0;
            RingController rCon3 = rS.rings[2].GetComponent<RingController>();
            rCon3.speed = 0;
            RingController rCon4 = rS.rings[3].GetComponent<RingController>();
            rCon4.speed = 0;
            RingController rCon5 = rS.rings[4].GetComponent<RingController>();
            rCon5.speed = 0;
        }
    }

    public void AddScore(int newScore)
    {
        if (!isGameOver)
        {
            gameData.score_Stage1 += newScore;
            score.text = string.Format("Score : {0 :00000}", gameData.score_Stage1);

            if (gameData.score_Stage1 > gameData.bestScore_Stage1)
            {
                gameData.bestScore_Stage1 = gameData.score_Stage1;
            }

            bestScore.text = string.Format("Best : {0 :00000}", gameData.bestScore_Stage1);
        }
    }

    public void StageRestart()
    {
        GFunc.LoadScene("StageScene");
    }

    public void StopObjects()
    {
        BackGroundController bGCon_L = bG_L.GetComponent<BackGroundController>();
        bGCon_L.enabled = false;
        BackGroundController bGCon_M = bG_M.GetComponent<BackGroundController>();
        bGCon_M.enabled = false;
        BackGroundController bGCon_R = bG_R.GetComponent<BackGroundController>();
        bGCon_R.enabled = false;

        FirePotController fPCon_L = fP_L.GetComponent<FirePotController>();
        fPCon_L.enabled = false;
        FirePotController fPCon_R = fP_R.GetComponent<FirePotController>();
        fPCon_R.enabled = false;
    }

    public void GameOver()
    {
        GFunc.LoadScene("TitleScene");
    }
}
