﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage10 : MonoBehaviour
{
    private int easyLevelat;
    private int hardLevelat;
    private int ultraLevelat;

    private float easyTime = 45f;
    private float hardTime = 30f;
    private float ultraTime = 15f;
    private float surviveTime;

    private int bestScore_10_easy;
    private int bestScore_10_hard;
    private int bestScore_10_ultra;
    private int gameModenum;

    private int coin;

    private bool isDone = false;

    private int minX = -15;
    private int maxX = -12;
    private int minY = -10;
    private int maxY = 10;
    private int obstacleNumber = 5;

    private int isGetTime;

    private bool isTimeRepeat;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        easyLevelat = PlayerPrefs.GetInt("easyLevelat");
        hardLevelat = PlayerPrefs.GetInt("hardLevelat");
        ultraLevelat = PlayerPrefs.GetInt("ultraLevelat");

        bestScore_10_easy = PlayerPrefs.GetInt("bestScore_10_easy", 1);
        bestScore_10_hard = PlayerPrefs.GetInt("bestScore_10_hard", 1);
        bestScore_10_ultra = PlayerPrefs.GetInt("bestScore_10_ultra", 1);
        gameModenum = PlayerPrefs.GetInt("gameMode");

        coin = PlayerPrefs.GetInt("Coin", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            if (Time.time > UIManager.instance.StartTime)
            {
                CountdownTimer();
                surviveTime += Time.deltaTime;

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
        isGetTime = PlayerPrefs.GetInt("IsTime", 0);
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

        if (gameModenum == 0)
        {
            if (surviveTime >= easyTime)
            {
                GameManager.instance.isPassed = true;
                UIManager.instance.stagepassscoreText.text = "Your Record  " + string.Format("{0:00}:{1:00}", minutes, seconds);

                if (easyLevelat <= 10)
                {
                    // 1분이 지났을때

                    UIManager.instance.SetActivePassTextUI(true);
                    PlayerPrefs.SetInt("easyLevelat", 11);

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
                if (hardLevelat <= 10)
                {
                    // 1분이 지났을때

                    UIManager.instance.SetActivePassTextUI(true);

                    PlayerPrefs.SetInt("hardLevelat", 11);

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
                if (ultraLevelat <= 10)
                {
                    // 1분이 지났을때

                    UIManager.instance.SetActivePassTextUI(true);
                    PlayerPrefs.SetInt("ultraLevelat", 11);

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
            if (surviveTime > bestScore_10_easy)
            {

                bestScore_10_easy = (int)surviveTime;
                PlayerPrefs.SetInt("bestScore_10_easy", (int)surviveTime); // 나중에 스테이지별 스크립트에서 가져오기
                UIManager.instance.SetActiveReachedBestUI(true);
            }
            bestScore_10_easy = PlayerPrefs.GetInt("bestScore_10_easy");

            int easy_minutes = (int)(bestScore_10_easy / 60) % 60;
            int easy_seconds = (int)(bestScore_10_easy % 60);

            UIManager.instance.bestScoreText.text = "Best  " + string.Format("{0:00}:{1:00}", easy_minutes, easy_seconds);
            UIManager.instance.SetActiveBestscoreUI(true);
        }

        if (gameModenum == 1)
        {
            if (surviveTime > bestScore_10_hard)
            {

                bestScore_10_hard = (int)surviveTime;
                PlayerPrefs.SetInt("bestScore_10_hard", (int)surviveTime); // 나중에 스테이지별 스크립트에서 가져오기
                UIManager.instance.SetActiveReachedBestUI(true);
            }
            bestScore_10_hard = PlayerPrefs.GetInt("bestScore_10_hard");

            int hard_minutes = (int)(bestScore_10_hard / 60) % 60;
            int hard_seconds = (int)(bestScore_10_hard % 60);

            UIManager.instance.bestScoreText.text = "Best  " + string.Format("{0:00}:{1:00}", hard_minutes, hard_seconds);
            UIManager.instance.SetActiveBestscoreUI(true);
        }

        if (gameModenum == 2)
        {
            if (surviveTime > bestScore_10_ultra)
            {

                bestScore_10_ultra = (int)surviveTime;
                PlayerPrefs.SetInt("bestScore_10_ultra", (int)surviveTime); // 나중에 스테이지별 스크립트에서 가져오기
                UIManager.instance.SetActiveReachedBestUI(true);
            }
            bestScore_10_ultra = PlayerPrefs.GetInt("bestScore_10_ultra");

            int ultra_minutes = (int)(bestScore_10_ultra / 60) % 60;
            int ultra_seconds = (int)(bestScore_10_ultra % 60);

            UIManager.instance.bestScoreText.text = "Best  " + string.Format("{0:00}:{1:00}", ultra_minutes, ultra_seconds);
            UIManager.instance.SetActiveBestscoreUI(true);
        }
    }
}
