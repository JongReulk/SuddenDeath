using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage7 : MonoBehaviour
{
    private int easyLevelat;
    private int hardLevelat;
    private int ultraLevelat;
    private int easyCoin;
    private int hardCoin;
    private int ultraCoin;

    private float easyTime = 45f;
    private float hardTime = 30f;
    private float ultraTime = 15f;
    private float surviveTime;
    private int surviveTime_floor;

    private int bestScore_7_easy;
    private int bestScore_7_hard;
    private int bestScore_7_ultra;
    private int gameModenum;

    private int coin;

    private bool isDone = false;
    private bool isStage7CoinDone = false;
    public GameObject Stage7CoinEgg;
    private AudioSource stage7Audio;

    public AudioClip stage7coinClip;

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

        bestScore_7_easy = PlayerPrefs.GetInt("bestScore_7_easy", 1);
        bestScore_7_hard = PlayerPrefs.GetInt("bestScore_7_hard", 1);
        bestScore_7_ultra = PlayerPrefs.GetInt("bestScore_7_ultra", 1);
        gameModenum = PlayerPrefs.GetInt("gameMode");

        easyCoin = PlayerPrefs.GetInt("easyCoin",0);
        hardCoin = PlayerPrefs.GetInt("hardCoin", 0);
        ultraCoin = PlayerPrefs.GetInt("ultraCoin", 0);

        coin = PlayerPrefs.GetInt("Coin", 0);

        stage7Audio = GetComponent<AudioSource>();
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
            surviveTime_floor = Mathf.FloorToInt(surviveTime);

            if (gameModenum == 0)
            {
                if (easyCoin == 0)
                {
                    if (surviveTime_floor == 7)
                    {
                        if (!isStage7CoinDone)
                        {
                            coin = coin + 3;
                            StartCoroutine(stage7CoinSet());
                            PlayerPrefs.SetInt("easyCoin", 1);
                            PlayerPrefs.SetInt("Coin", coin);
                            isStage7CoinDone = true;
                        }
                    }
                }
            }

            if (gameModenum == 1)
            {
                if (hardCoin == 0)
                {
                    if (surviveTime_floor == 7)
                    {
                        if (!isStage7CoinDone)
                        {
                            coin = coin + 3;
                            StartCoroutine(stage7CoinSet());
                            PlayerPrefs.SetInt("hardCoin", 1);
                            PlayerPrefs.SetInt("Coin", coin);
                            isStage7CoinDone = true;
                        }
                    }
                }
            }

            if (gameModenum == 2)
            {
                if (ultraCoin == 0)
                {
                    if (surviveTime_floor == 7)
                    {
                        if (!isStage7CoinDone)
                        {
                            coin = coin + 3;
                            StartCoroutine(stage7CoinSet());
                            PlayerPrefs.SetInt("ultraCoin", 1);
                            PlayerPrefs.SetInt("Coin", coin);
                            isStage7CoinDone = true;
                        }
                    }
                }
            }
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

        int minutes = (int)(Mathf.FloorToInt(surviveTime) / 60) % 60;
        int seconds = (int)(Mathf.FloorToInt(surviveTime) % 60);

        if (gameModenum == 0)
        {
            


            if (surviveTime >= easyTime)
            {
                GameManager.instance.isPassed = true;
                UIManager.instance.stagepassscoreText.text = "Your Record  " + string.Format("{0:00}:{1:00}", minutes, seconds);

                if (easyLevelat <= 7)
                {
                    // 1분이 지났을때

                    UIManager.instance.SetActivePassTextUI(true);
                    PlayerPrefs.SetInt("easyLevelat", 8);

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
                if (hardLevelat <= 7)
                {
                    // 1분이 지났을때

                    UIManager.instance.SetActivePassTextUI(true);

                    PlayerPrefs.SetInt("hardLevelat", 8);

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
                if (ultraLevelat <= 7)
                {
                    // 1분이 지났을때

                    UIManager.instance.SetActivePassTextUI(true);
                    PlayerPrefs.SetInt("ultraLevelat", 8);

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
            if (surviveTime > bestScore_7_easy)
            {

                bestScore_7_easy = (int)surviveTime;
                PlayerPrefs.SetInt("bestScore_7_easy", (int)surviveTime); // 나중에 스테이지별 스크립트에서 가져오기
                UIManager.instance.SetActiveReachedBestUI(true);
            }
            bestScore_7_easy = PlayerPrefs.GetInt("bestScore_7_easy");

            int easy_minutes = (int)(bestScore_7_easy / 60) % 60;
            int easy_seconds = (int)(bestScore_7_easy % 60);

            UIManager.instance.bestScoreText.text = "Best  " + string.Format("{0:00}:{1:00}", easy_minutes, easy_seconds);
            UIManager.instance.SetActiveBestscoreUI(true);
        }

        if (gameModenum == 1)
        {
            if (surviveTime > bestScore_7_hard)
            {

                bestScore_7_hard = (int)surviveTime;
                PlayerPrefs.SetInt("bestScore_7_hard", (int)surviveTime); // 나중에 스테이지별 스크립트에서 가져오기
                UIManager.instance.SetActiveReachedBestUI(true);
            }
            bestScore_7_hard = PlayerPrefs.GetInt("bestScore_7_hard");

            int hard_minutes = (int)(bestScore_7_hard / 60) % 60;
            int hard_seconds = (int)(bestScore_7_hard % 60);

            UIManager.instance.bestScoreText.text = "Best  " + string.Format("{0:00}:{1:00}", hard_minutes, hard_seconds);
            UIManager.instance.SetActiveBestscoreUI(true);
        }

        if (gameModenum == 2)
        {
            if (surviveTime > bestScore_7_ultra)
            {

                bestScore_7_ultra = (int)surviveTime;
                PlayerPrefs.SetInt("bestScore_7_ultra", (int)surviveTime); // 나중에 스테이지별 스크립트에서 가져오기
                UIManager.instance.SetActiveReachedBestUI(true);
            }
            bestScore_7_ultra = PlayerPrefs.GetInt("bestScore_7_ultra");

            int ultra_minutes = (int)(bestScore_7_ultra / 60) % 60;
            int ultra_seconds = (int)(bestScore_7_ultra % 60);

            UIManager.instance.bestScoreText.text = "Best  " + string.Format("{0:00}:{1:00}", ultra_minutes, ultra_seconds);
            UIManager.instance.SetActiveBestscoreUI(true);
        }
    }

    IEnumerator stage7CoinSet()
    {
        Stage7CoinEgg.SetActive(true);
        stage7Audio.PlayOneShot(stage7coinClip);
        
        yield return new WaitForSeconds(2f);
        Stage7CoinEgg.SetActive(false);
    }

    


}
