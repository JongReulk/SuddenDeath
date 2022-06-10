using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool isGameover = false;

    public Toggle settingToggle;

    public bool gameOverRestart = false;
    

    //public GameObject bulletRespawn;

    public GameObject[] playerCount;

    //public GameObject AddTimeItem;


    [Header("SoundEffect")]
    private AudioSource soundEffectAudioPlayer;
    public AudioClip deathClip; // 사망 소리
    public AudioClip gameoverClip;
    public AudioClip stageClip;
    public AudioClip passClip;
    public AudioClip CoinItem;
    public AudioClip ShieldItem;
    public bool isCoinItem;
    public bool isShieldItem;



    private int randomAds;


    public int PassedStage;

    public bool isPassed = false;
    private int playernum;
    private int gameoverRestart;
    private int isSkull;
    private bool getSkull = false;
    private bool isoverRestart = false;
    public AudioSource Music;
    private int stageHelp_1;

    [Header("Joystick")]
    public GameObject Player1_Joystick_L;
    public GameObject Player1_Joystick_R;
    public GameObject Player2_Joystick_L;
    public GameObject Player2_Joystick_R;
    public GameObject twoPlayerjoystick;
    
    private string Player1_Joystick;
    private string Player2_Joystick;

    private int gameModenum;

    [Header("Object Pool")]
    public GameObject bulletPrefab;
    public int maxPool = 30;
    public List<GameObject> bulletPool = new List<GameObject>();

    [Header("ObstaclePooling")]
    public GameObject ObstaclePrefab;
    //public GameObject bulletPrefab;
    private int maxPool_ob = 5;
    public List<GameObject> obstaclePool = new List<GameObject>();

    [Header("Ads")]
    public GameObject bannerAd;
    public GameObject ScreenAd;
    public GameObject PassAds;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
        CreatePooling();
        CreateObstacle();
        

        playernum = PlayerPrefs.GetInt("Playernum",1);
        Player1_Joystick = PlayerPrefs.GetString("Player1_Joystick", "R");
        Player2_Joystick = PlayerPrefs.GetString("Player2_Joystick", "R");
        gameoverRestart = PlayerPrefs.GetInt("gameoverRestart", 0);
        isSkull = PlayerPrefs.GetInt("isSkull", 0);

        if (playernum == 2)
        {
            twoPlayerjoystick.SetActive(true);
            playerCount[1].SetActive(true);
        }

        CheckJoystick();

    }

    // Start is called before the first frame update
    void Start()
    {

        gameModenum = PlayerPrefs.GetInt("gameMode");

        soundEffectAudioPlayer = GetComponent<AudioSource>();
        
        isGameover = false;
        isPassed = false;

        stageHelp_1 = PlayerPrefs.GetInt("stageHelp_1", 0);
        isCoinItem = false;
        isShieldItem = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(isCoinItem)
        {
            soundEffectAudioPlayer.PlayOneShot(CoinItem);
            isCoinItem = false;
        }

        if(isShieldItem)
        {
            soundEffectAudioPlayer.PlayOneShot(ShieldItem);
            isShieldItem = false;
        }

        if(isGameover && gameOverRestart)
        {
            if(!isoverRestart)
            {
                StartCoroutine(GameoverRestart());
                isoverRestart = true;
            }
            
            
            
        }
        if(isSkull == 0 )
        {
            if(gameoverRestart > 10)
            {
                if(!getSkull)
                {
                    PlayerPrefs.SetInt("isSkull", 1);
                    isSkull = PlayerPrefs.GetInt("isSkull"); // 나중에 지우기 확인용
                    getSkull = true;
                }
            }
        }

    }


    public void EndGame()
    {
        if(playernum == 1)
        {
            isGameover = true;
            

            UIManager.instance.pauseButton.interactable = false;
            int orderRandom = Random.Range(0, 3);


            //if 문 넣기 pass or fail
            if (isPassed == true)
            {
                if (orderRandom == 0)
                {
                    bannerAd.SetActive(true);
                }
                else 
                {
                    AdmobScreenAd.instance.Show();
                }
                
                soundEffectAudioPlayer.PlayOneShot(passClip);
                Music.Stop();
                UIManager.instance.SetActivePassUI(true);
            }

            else
            {
                Music.Stop();

                soundEffectAudioPlayer.PlayOneShot(deathClip);

                soundEffectAudioPlayer.PlayOneShot(gameoverClip);

                UIManager.instance.SetActiveGameoverUI(true);

                bannerAd.SetActive(true);
                if(orderRandom == 0)
                {
                    AdmobScreenAd.instance.Show();
                }
                
            }
        }

        if(playernum == 2)
        {
            if(!playerCount[0].activeSelf && !playerCount[1].activeSelf)
            {
                int orderRandom = Random.Range(0, 3);
                UIManager.instance.pauseButton.interactable = false;
                isGameover = true;
                

                //if 문 넣기 pass or fail
                if (isPassed == true)
                {
                    ScreenAd.SetActive(true);
                    Music.Stop();
                    soundEffectAudioPlayer.PlayOneShot(passClip);
                    UIManager.instance.SetActivePassUI(true);
                    bannerAd.SetActive(true);

                    if (orderRandom == 0)
                    {
                        bannerAd.SetActive(true);
                    }
                    else
                    {
                        AdmobScreenAd.instance.Show();
                    }
                }

                else
                {
                    Music.Stop();

                    soundEffectAudioPlayer.PlayOneShot(deathClip);

                    soundEffectAudioPlayer.PlayOneShot(gameoverClip);

                    UIManager.instance.SetActiveGameoverUI(true);

                    bannerAd.SetActive(true);
                    if (orderRandom == 0)
                    {
                        ScreenAd.SetActive(true);
                    }
                }
            }
                
        }
        
        

    }


    IEnumerator GameoverRestart()
    {
        gameoverRestart++;
        PlayerPrefs.SetInt("gameoverRestart", gameoverRestart);

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    public void ClickOnGameOverRestartButton()
    {
        soundEffectAudioPlayer.PlayOneShot(stageClip);
        gameOverRestart = true;
    }

    public void EffectChangeValue()
    {
        if (settingToggle.isOn == true)
        {
            soundEffectAudioPlayer.mute = false;
        }
        else
        {
            soundEffectAudioPlayer.mute = true;
        }
    }


    public void CheckJoystick()
    {
        
        if (Player1_Joystick == "L")
        {
            Player1_Joystick_L.SetActive(true);
            Player1_Joystick_R.SetActive(false);
        }
        if (Player1_Joystick == "R")
        {
            Player1_Joystick_L.SetActive(false);
            Player1_Joystick_R.SetActive(true);
        }

        if (Player2_Joystick == "L")
        {
            Player2_Joystick_L.SetActive(true);
            Player2_Joystick_R.SetActive(false);
        }

        if (Player2_Joystick == "R")
        {
            Player2_Joystick_L.SetActive(false);
            Player2_Joystick_R.SetActive(true);
        }
        

        
    }
    


    // 총알을 가져오는 함수
    public GameObject GetBullet()
    {
        for(int i = 0; i < bulletPool.Count; i++)
        {
            if (bulletPool[i].activeSelf == false)
            {
                return bulletPool[i];
            }
        }
        
        return null;
    }

    // 오브젝트 풀에 총알을 생성하는 함수
    public void CreatePooling()
    {
        GameObject objectPools = new GameObject("ObjectPools");

        for(int i = 0; i < maxPool; i++)
        {
            var obj = Instantiate<GameObject>(bulletPrefab, objectPools.transform);
            obj.name = "Bullet_" + i.ToString("00");

            obj.SetActive(false);

            bulletPool.Add(obj);
        }
        
    }

    // 총알을 가져오는 함수
    public GameObject GetObstacle()
    {
        for (int i = 0; i < obstaclePool.Count; i++)
        {
            if (obstaclePool[i].activeSelf == false)
            {
                return obstaclePool[i];
            }
        }

        return null;
    }

    // 오브젝트 풀에 총알을 생성하는 함수
    public void CreateObstacle()
    {
        GameObject objectPools = new GameObject("ObjectPools");

        if(gameModenum == 0)
        {
            maxPool_ob = 2;
        }

        if (gameModenum == 1)
        {
            maxPool_ob = 3;
        }

        if (gameModenum == 2)
        {
            maxPool_ob = 5;
        }

        for (int i = 0; i < maxPool_ob; i++)
        {
            var obj = Instantiate<GameObject>(ObstaclePrefab, objectPools.transform);
            obj.name = "Obstacle_" + i.ToString("00");

            obj.SetActive(false);

            obstaclePool.Add(obj);
        }

    }

    IEnumerator GetShield()
    {

        PlayerPrefs.SetInt("isShield", 1);

        yield return new WaitForSeconds(3.0f);

        PlayerPrefs.SetInt("isShield", 0);

        gameObject.SetActive(false);
    }

    
}
