using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    

    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();


            }

            return m_instance;
        }
    }

    private static UIManager m_instance;

    float gameTime = 10f;
    public float startTime;

    public Text timerText;
    
    public Text scoreText;
    public Text stagepassscoreText;
    public Text bestScoreText;
    public GameObject passUI;
    public GameObject stagePassUI;
    public GameObject bestScoreUI;
    public GameObject reachedBestUI;

    
    public Toggle settingToggle;

    
    
    public bool isStagePassed = false;

    public int bestScore;

    public float StartTime = 0.5f;

    public float surviveTime;

    private bool isTimeRepeat;

    private int isGetTime;


    [Header("Game Over")]
    public bool isGameoverBack = false;
    public GameObject gameoverUI;


    [Header("Pause Menu")]
    public Button pauseButton;
    
    public GameObject pauseUI;
    public GameObject settingUI;
    public bool isRestart = false;
    public bool isResume = false;
    public bool isPaused = false;
    public bool isSetting = false;
    public bool isSettingBack = false;
    public bool isQuited = false;

    [Header("JoyStick")]
    public Image Player1_L;
    public Image Player1_R;
    public Image Player2_L;
    public Image Player2_R;
    private string Player1_joystick;
    private string Player2_joystick;

    [Header("SoundEffect")]
    private AudioSource UIAudio;
    public AudioClip stageClickClip;
    public AudioClip joystickSelectClip;
    public AudioClip GetTimeItem;

    






    private void Awake()
    {
        gameoverUI.SetActive(false);
        pauseButton.interactable = true;
        bestScore = PlayerPrefs.GetInt("bestScore", 1);
        Player1_joystick = PlayerPrefs.GetString("Player1_Joystick", "R");
        Player2_joystick = PlayerPrefs.GetString("Player2_Joystick", "R");
        isTimeRepeat = false;
        surviveTime = 0f;
    }

    private void Start()
    {
        if (Player1_joystick == "L")
        {
            Player1_L.color = Color.red;
            Player1_R.color = Color.white;
        }

        if (Player1_joystick == "R")
        {
            Player1_L.color = Color.white;
            Player1_R.color = Color.red;
        }

        if (Player2_joystick == "L")
        {
            Player2_L.color = Color.blue;
            Player2_R.color = Color.white;
        }

        if (Player2_joystick == "R")
        {
            Player2_L.color = Color.white;
            Player2_R.color = Color.blue;
        }

        UIAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        isGetTime = PlayerPrefs.GetInt("IsTime", 0);

        if (!GameManager.instance.isGameover)
        {
            if(Time.time > StartTime)
            {
                if(isGetTime == 1)
                {
                    if (!isTimeRepeat)
                    {
                        UIAudio.PlayOneShot(GetTimeItem);
                        surviveTime += 3f;
                        //PlayerPrefs.SetInt("IsTime", 0);
                    }

                }
                surviveTime += Time.deltaTime;
                CountdownTimer();
                
                
                
                
            }
        }
        /*
        if(GameManager.instance.isGameover)
        {
            SetActiveBestscoreUI(true);

            if (surviveTime > bestScore)
            {
                
                bestScore = (int)surviveTime;
                PlayerPrefs.SetInt("bestScore", (int)surviveTime); // 나중에 스테이지별 스크립트에서 가져오기
                SetActiveReachedBestUI(true);
                
            }
        }*/

        if (isPaused == true)
        {
            pauseButton.interactable = false;

            Time.timeScale = 0.0f;

            if (isResume == true)
            {
                isPaused = false;
                Time.timeScale = 1.0f;
                SetActivePaussUI(false);
                isResume = false;
                pauseButton.interactable = true;
            }

            if (isRestart == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                isPaused = false;
                Time.timeScale = 1.0f;
                isRestart = false;

            }

            if (isSetting == true)
            {

                SetActiveSettingUI(true);

                

                if (isSettingBack == true)
                {
                    SetActiveSettingUI(false);

                    

                    isSetting = false;

                    isSettingBack = false;

                }

               

            }

            if (isQuited == true)
            {
                SceneManager.LoadScene("Start");
                isPaused = false;
                isQuited = false;
                Time.timeScale = 1.0f;
                //SceneManager.LoadScene("Start");
            }


        }

        if(isGameoverBack == true)
        {
            SceneManager.LoadScene("Start");
        }



    }

    void CountdownTimer()
    {
        //float timerTime = Time.time;

        //int minutes = (int)((gameTime - timerTime) / 60) % 60;
        //int seconds = (int)((gameTime - timerTime) % 60);

        int minutes = (int)(surviveTime / 60) % 60;
        int seconds = (int)(surviveTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        scoreText.text = "Your Record  " + string.Format("{0:00}:{1:00}", minutes, seconds);

        /*
        if (surviveTime >= gameTime)
        {
            // 1분이 지났을때
            GameManager.instance.isPassed = true;
            SetActivePassTextUI(true);
            stagepassscoreText.text = "Your Record  " + string.Format("{0:00}:{1:00}", minutes, seconds);

        }*/
    }

    public void ClickOnRestartButton()
    {
        UIAudio.PlayOneShot(stageClickClip);
        isRestart = true;
    }

    public void ClickOnResumeButton()
    {
        UIAudio.PlayOneShot(stageClickClip);
        isResume = true;
    }

    public void ClickOnPauseButton()
    {
        UIAudio.PlayOneShot(stageClickClip);
        isPaused = true;
        SetActivePaussUI(true);
    }

    public void ClickOnSetting()
    {
        UIAudio.PlayOneShot(stageClickClip);
        isSetting = true;
    }

    public void ClickOnSettingBack()
    {
        UIAudio.PlayOneShot(stageClickClip);
        isSettingBack = true;
    }

    public void ClickOnPauseQuit()
    {
        UIAudio.PlayOneShot(stageClickClip);
        isQuited = true;
    }

    public void ClickOnGameoverBack()
    {
        UIAudio.PlayOneShot(stageClickClip);
        isGameoverBack = true;
    }

    public void ClickOnPassBack()
    {
        UIAudio.PlayOneShot(stageClickClip);
        isGameoverBack = true;
    }

    public void ClickOnChangeCharacter()
    {
        PlayerPrefs.SetInt("IsCharacter",1);
        SceneManager.LoadScene("Start");
    }

    public void ClickOn1PlayerJoystick_L()
    {
        UIAudio.PlayOneShot(joystickSelectClip);
        PlayerPrefs.SetString("Player1_Joystick", "L");
        Player1_L.color = Color.red;
        Player1_R.color = Color.white;
    }

    public void ClickOn1PlayerJoystick_R()
    {
        UIAudio.PlayOneShot(joystickSelectClip);
        PlayerPrefs.SetString("Player1_Joystick", "R");
        Player1_L.color = Color.white;
        Player1_R.color = Color.red;
    }

    public void ClickOn2PlayerJoystick_L()
    {
        UIAudio.PlayOneShot(joystickSelectClip);
        PlayerPrefs.SetString("Player2_Joystick", "L");
        Player2_L.color = Color.blue;
        Player2_R.color = Color.white;
    }

    public void ClickOn2PlayerJoystick_R()
    {
        UIAudio.PlayOneShot(joystickSelectClip);
        PlayerPrefs.SetString("Player2_Joystick", "R");
        Player2_L.color = Color.white;
        Player2_R.color = Color.blue;
    }


    public void SetActiveGameoverUI(bool active)
    {
        gameoverUI.SetActive(active);
        

    }

    public void SetActivePassUI(bool active)
    {
        stagePassUI.SetActive(active);
        

    }

    public void SetActivePassTextUI(bool active)
    {
        passUI.SetActive(active);
    }

    public void SetActivePaussUI(bool active)
    {
        pauseUI.SetActive(active);
    }

    public void SetActiveSettingUI(bool active)
    {
        settingUI.SetActive(active);
    }

    public void SetActiveBestscoreUI(bool active)
    {
        bestScoreUI.SetActive(active);

        /*
        int bestTime = PlayerPrefs.GetInt("bestScore");
        
        int minutes = (int)(bestTime / 60) % 60;
        int seconds = (int)(bestTime % 60);

        bestScoreText.text = "Best  " + string.Format("{0:00}:{1:00}", minutes, seconds);
        */
    }

    public void SetActiveReachedBestUI(bool active)
    {
        reachedBestUI.SetActive(active);
    }

    
    


    
}
