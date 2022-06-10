using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    private int easyLevelat;
    private int hardLevelat;
    private int ultraLevelat;

    private float easyTime = 45f;
    private float hardTime = 30f;
    private float ultraTime = 15f;
    private float surviveTime;

    private int bestScore_1_easy;
    private int bestScore_1_hard;
    private int bestScore_1_ultra;
    private int gameModenum;

    public GameObject stage_1HelpUI;
    

    private int coin;

    private int isGetTime;

    private bool isTimeRepeat;

    private bool isDone = false;

    private int isstageHelp;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        easyLevelat = PlayerPrefs.GetInt("easyLevelat",1);
        hardLevelat = PlayerPrefs.GetInt("hardLevelat",1);
        ultraLevelat = PlayerPrefs.GetInt("ultraLevelat",1);

        bestScore_1_easy = PlayerPrefs.GetInt("bestScore_1_easy", 1);
        bestScore_1_hard = PlayerPrefs.GetInt("bestScore_1_hard", 1);
        bestScore_1_ultra = PlayerPrefs.GetInt("bestScore_1_ultra", 1);
        gameModenum = PlayerPrefs.GetInt("gameMode");

        isstageHelp = PlayerPrefs.GetInt("isstageHelp", 0);

        coin = PlayerPrefs.GetInt("Coin", 0);

        isTimeRepeat = false;

        surviveTime = 0;

        /*
        if (easyLevelat == 1 && hardLevelat == 1 & ultraLevelat == 1)
        {
            if(isstageHelp == 0)
            {
                GameManager.instance.isGameover = true;
                stage_1HelpUI.SetActive(true);
                PlayerPrefs.SetInt("isstageHelp", 1);
            }
        }*/
        

    }

    // Update is called once per frame
    void Update()
    {
        

        if (!GameManager.instance.isGameover)
        {
            if (Time.time > UIManager.instance.StartTime)
            {
                
                surviveTime += Time.deltaTime;
                CountdownTimer();
                

                

            }


        }

        if (GameManager.instance.isGameover)
        {
            ShowBestScore();
        }
        //CountdownTimer();
        //surviveTime += Time.deltaTime;
    }

    void CountdownTimer()
    {
        isGetTime =  PlayerPrefs.GetInt("IsTime", 0);
        //float timerTime = Time.time;
        if (isGetTime == 1)
        {
            if (!isTimeRepeat)
            {
                
                surviveTime += 3f;
                PlayerPrefs.SetInt("IsTime", 0);
            }

        }

        

        int minutes = (int)(surviveTime / 60) % 60;
        int seconds = (int)(surviveTime % 60);

        if (gameModenum == 0 )
        {
            
            if (surviveTime >= easyTime)
            {
                GameManager.instance.isPassed = true;
                UIManager.instance.stagepassscoreText.text = "Your Record  " + string.Format("{0:00}:{1:00}", minutes, seconds);

                

                if (easyLevelat <= 1)
                {
                    // 1분이 지났을때
                    
                    PlayerPrefs.SetInt("easyLevelat", 2);

                    UIManager.instance.SetActivePassTextUI(true);

                    if (!isDone)
                    {
                        coin = coin + 1;
                        PlayerPrefs.SetInt("Coin", coin);
                        isDone = true;
                    }
                }
            }
        }
        
        if (gameModenum == 1)
        {
            if (surviveTime >= hardTime)

            {
                GameManager.instance.isPassed = true;
                UIManager.instance.stagepassscoreText.text = "Your Record  " + string.Format("{0:00}:{1:00}", minutes, seconds);
                if (hardLevelat <= 1)
                {
                    // 1분이 지났을때

                    UIManager.instance.SetActivePassTextUI(true);

                    PlayerPrefs.SetInt("hardLevelat", 2);

                    if (!isDone)
                    {
                        coin = coin + 2;
                        PlayerPrefs.SetInt("Coin", coin);
                        isDone = true;
                    }

                }
            }
        }
        
        if (gameModenum == 2)
        {
            if (surviveTime >= ultraTime)
            {
                GameManager.instance.isPassed = true;
                UIManager.instance.stagepassscoreText.text = "Your Record  " + string.Format("{0:00}:{1:00}", minutes, seconds);
                if (ultraLevelat <= 1)
                {
                    // 1분이 지났을때

                    UIManager.instance.SetActivePassTextUI(true);
                    PlayerPrefs.SetInt("ultraLevelat", 2);

                    if (!isDone)
                    {
                        coin = coin + 3;
                        PlayerPrefs.SetInt("Coin", coin);
                        isDone = true;
                    }

                }

            }
        }
        

    }

    void ShowBestScore()
    {
        if (gameModenum == 0)
        {
            if (surviveTime > bestScore_1_easy)
            {

                bestScore_1_easy = (int)surviveTime;
                PlayerPrefs.SetInt("bestScore_1_easy", (int)surviveTime); // 나중에 스테이지별 스크립트에서 가져오기
                UIManager.instance.SetActiveReachedBestUI(true);
            }
            bestScore_1_easy = PlayerPrefs.GetInt("bestScore_1_easy");

            int easy_minutes = (int)(bestScore_1_easy / 60) % 60;
            int easy_seconds = (int)(bestScore_1_easy % 60);

            UIManager.instance.bestScoreText.text = "Best  " + string.Format("{0:00}:{1:00}", easy_minutes, easy_seconds);
            UIManager.instance.SetActiveBestscoreUI(true);
        }

        if (gameModenum == 1)
        {
            if (surviveTime > bestScore_1_hard)
            {

                bestScore_1_hard = (int)surviveTime;
                PlayerPrefs.SetInt("bestScore_1_hard", (int)surviveTime); // 나중에 스테이지별 스크립트에서 가져오기
                UIManager.instance.SetActiveReachedBestUI(true);
            }
            bestScore_1_hard = PlayerPrefs.GetInt("bestScore_1_hard");

            int hard_minutes = (int)(bestScore_1_hard / 60) % 60;
            int hard_seconds = (int)(bestScore_1_hard % 60);

            UIManager.instance.bestScoreText.text = "Best  " + string.Format("{0:00}:{1:00}", hard_minutes, hard_seconds);
            UIManager.instance.SetActiveBestscoreUI(true);
        }

        if (gameModenum == 2)
        {
            if (surviveTime > bestScore_1_ultra)
            {

                bestScore_1_ultra = (int)surviveTime;
                PlayerPrefs.SetInt("bestScore_1_ultra", (int)surviveTime); // 나중에 스테이지별 스크립트에서 가져오기
                UIManager.instance.SetActiveReachedBestUI(true);
            }
            bestScore_1_ultra = PlayerPrefs.GetInt("bestScore_1_ultra");

            int ultra_minutes = (int)(bestScore_1_ultra / 60) % 60;
            int ultra_seconds = (int)(bestScore_1_ultra % 60);

            UIManager.instance.bestScoreText.text = "Best  " + string.Format("{0:00}:{1:00}", ultra_minutes, ultra_seconds);
            UIManager.instance.SetActiveBestscoreUI(true);
        }
    }
}

  
