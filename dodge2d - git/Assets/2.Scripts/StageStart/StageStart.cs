using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageStart : MonoBehaviour
{

    public GameObject StartStageUI;
    public GameObject LastStageUI;
    public GameObject CharacterUI;

    public Button[] Buttons;

    public GameObject[] stages; // 스테이지 일반 상태
    public GameObject[] stagePass; // 스테이지 패스
    public GameObject[] stageLock; // 스테이지 잠김
    public int isCharacter;

    public bool isPlayer1;
    public bool isPlayer2;
    

    private int Player1_Character;
    private int Player2_Character;
    

    private int easyLevelat;
    private int hardLevelat;
    private int ultraLevelat;

    private int playernum;

    public Image[] CharacterImage;
    public GameObject[] PlayerCharacter;

    public GameObject StartHelp;
    //public Button[] characterButton;

    private int isHelped;
    public GameObject CharacterHelpUI;

    private int isCharacterUI;





    private int gameModenum;

    [Header("Coin")]
    public Text coinText;
    private int coin;
   
    private bool isDifficultyCoinDone = false;
    private bool isCoinDone = false;
    private int DifficultyCoin;
    private int StartCoin;
    private int DifficultyCoinCount;
    private int StartCoinCount;
    public GameObject StartCoinEgg;
    public GameObject DifficultyCoinEgg; 



    [Header("Setting")]
    public GameObject settingUI_Start;
    public Slider StartMusicSlider;
    public Text StartMusicText;
    public Slider SoundEffectSlider;
    public Text SoundEffectText;

    [Header("SoundEffect")]
    public AudioClip clickClip; // 클릭 소리
    public AudioClip playerSelectClip;
    public AudioClip characterSelectClip;
    private AudioSource soundEffectAudioPlayer;
    public AudioClip startCoinClip;

    [Header("NewCharacter")]
    public Button Skullbutton;
    public Button Astrobutton;
    public Image SkullImage;
    public Image AstroImage;
    private Color AstroColor;
    private Color SkullColor;
    private int isSkull;
    private int isAstro;
    private int getSkull;
    private int getAstro;
    public GameObject SkullUI;
    public GameObject AstroUI;

    private int isRepeat;
    private int isCharacterRepeat;

    // Start is called before the first frame update
    void Start()
    {
        //easyLevelat = 2;
        //hardLevelat = 3;
        //ultraLevelat = 4;
        isHelped = PlayerPrefs.GetInt("Help", 0);
        isRepeat = PlayerPrefs.GetInt("isRepeat", 0);
        isCharacterRepeat = PlayerPrefs.GetInt("isCharacterRepeat", 0);




        easyLevelat = PlayerPrefs.GetInt("easyLevelat", 1);
        hardLevelat = PlayerPrefs.GetInt("hardLevelat", 1);
        ultraLevelat = PlayerPrefs.GetInt("ultraLevelat", 1);

        if(easyLevelat == 1 && hardLevelat == 1 && ultraLevelat == 1)
        {
            if (isRepeat == 0)
            {
                StartHelp.SetActive(true);
                PlayerPrefs.SetInt("isRepeat", 1);
            }

        }

        gameModenum = PlayerPrefs.GetInt("gameMode");

        playernum = PlayerPrefs.GetInt("Playernum");

        coin = PlayerPrefs.GetInt("Coin", 0);

        StartCoin = PlayerPrefs.GetInt("StartCoin", 0);

        DifficultyCoin = PlayerPrefs.GetInt("DifficultyCoin", 0);

        isSkull = PlayerPrefs.GetInt("isSkull", 0);

        getSkull = PlayerPrefs.GetInt("getSkull", 0);

        getAstro = PlayerPrefs.GetInt("getAstro", 0);

        isCharacterUI = PlayerPrefs.GetInt("IsCharacter", 0);


        Debug.Log("isCharacterUI = " + isCharacterUI);

        if(isCharacterUI == 1)
        {
            isCharacterSet();
            PlayerPrefs.SetInt("IsCharacter", 0);

        }


        // 패스 상태 활성화


        // 플레이어 캐릭터 선택
        for (int i = 0; i<playernum; i++)
        {
            PlayerCharacter[i].SetActive(true);
        }

        for (int i = playernum; i < PlayerCharacter.Length; i++)
        {
            PlayerCharacter[i].SetActive(false);
        }

        soundEffectAudioPlayer = GetComponent<AudioSource>();

        if (getSkull == 0)
        {
            if (isSkull == 1)
            {
                SkullUI.SetActive(true);
                SkullColor = SkullImage.color;
                SkullColor.a = 1.0f;
                SkullImage.color = SkullColor;

                Skullbutton.interactable = true;
                PlayerPrefs.SetInt("getSkull", 1);
            }
        }
        if(isSkull ==1)
        {
            SkullColor = SkullImage.color;
            SkullColor.a = 1.0f;
            SkullImage.color = SkullColor;

            Skullbutton.interactable = true;
            PlayerPrefs.SetInt("getSkull", 1);
        }

        if(getAstro == 0)
        {
            if(easyLevelat >= 11 || hardLevelat >= 11 || ultraLevelat >= 11)
            {
                AstroUI.SetActive(true);
                AstroColor = AstroImage.color;
                AstroColor.a = 1.0f;
                AstroImage.color = AstroColor;

                Astrobutton.interactable = true;
                PlayerPrefs.SetInt("getAstro", 1);
            }
        }

        if (easyLevelat >= 11 || hardLevelat >= 11 || ultraLevelat >= 11)
        {
            AstroColor = AstroImage.color;
            AstroColor.a = 1.0f;
            AstroImage.color = AstroColor;

            Astrobutton.interactable = true;
            //PlayerPrefs.SetInt("getAstro", 1);
        }




    }

    // Update is called once per frame
    void Update()
    {
        gameModenum = PlayerPrefs.GetInt("gameMode");
        coin = PlayerPrefs.GetInt("Coin", 0);

        SetCoinText();

        
        if (StartCoin == 0)
        {
            if(StartCoinCount == 5)
            {
                if(!isCoinDone)
                {
                    coin = coin + 3;
                    PlayerPrefs.SetInt("StartCoin", 1);
                    PlayerPrefs.SetInt("Coin", coin);
                    StartCoroutine(startCoinSet());
                    isCoinDone = true;
                }
                
            }
        }

        if (DifficultyCoin == 0)
        {
            if (DifficultyCoinCount == 7)
            {
                if (!isDifficultyCoinDone)
                {
                    coin = coin+3;
                    PlayerPrefs.SetInt("DifficultyCoin", 1);
                    PlayerPrefs.SetInt("Coin", coin);
                    StartCoroutine(DifficultyCoinSet());
                    isDifficultyCoinDone = true;
                }

            }
        }

        if (gameModenum == 0)
        {
            StartCoroutine("SetEasyModeStage");
        }

        if (gameModenum == 1)
        {
            StartCoroutine("SetHardModeStage");
        }

        if (gameModenum == 2)
        {
            StartCoroutine("SetUltraModeStage");
        }

        //StartCoroutine("ChangeGameModeStage");

        StartCoroutine("ChangeCharacterColor");


    }

    IEnumerator startCoinSet()
    {
        StartCoinEgg.SetActive(true);
        soundEffectAudioPlayer.PlayOneShot(startCoinClip);
        yield return new WaitForSeconds(2f);
        StartCoinEgg.SetActive(false);
    }

    IEnumerator DifficultyCoinSet()
    {
        DifficultyCoinEgg.SetActive(true);
        soundEffectAudioPlayer.PlayOneShot(startCoinClip);
        yield return new WaitForSeconds(2f);
        DifficultyCoinEgg.SetActive(false);
    }

    IEnumerator SetEasyModeStage()
    {
        for (int i = 0; i < easyLevelat - 1; i++)
        {
            stages[i].SetActive(false);
            stagePass[i].SetActive(true);
            stageLock[i].SetActive(false);
            Buttons[i].interactable = true;
        }

        // 기본 상태 활성화
        stages[easyLevelat-1].SetActive(true);
        stagePass[easyLevelat-1].SetActive(false);
        stageLock[easyLevelat-1].SetActive(false);
        Buttons[easyLevelat-1].interactable = true;

        //levelat = PlayerPrefs.GetInt("levelReached"); //for(int i = levelat+1) 대신 사용
        // Lock 활성화
        for (int i = easyLevelat; i < stages.Length; i++)
        {
            stages[i].SetActive(false);
            stagePass[i].SetActive(false);
            stageLock[i].SetActive(true);
            Buttons[i].interactable = false;
        }
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator SetHardModeStage()
    {
        for (int i = 0; i < hardLevelat - 1; i++)
        {
            stages[i].SetActive(false);
            stagePass[i].SetActive(true);
            stageLock[i].SetActive(false);
            Buttons[i].interactable = true;
        }

        // 기본 상태 활성화
        stages[hardLevelat-1].SetActive(true);
        stagePass[hardLevelat-1].SetActive(false);
        stageLock[hardLevelat-1].SetActive(false);
        Buttons[hardLevelat-1].interactable = true;

        //levelat = PlayerPrefs.GetInt("levelReached"); //for(int i = levelat+1) 대신 사용
        // Lock 활성화
        for (int i = hardLevelat; i < stages.Length; i++)
        {
            stages[i].SetActive(false);
            stagePass[i].SetActive(false);
            stageLock[i].SetActive(true);
            Buttons[i].interactable = false;
        }

        yield return new WaitForSeconds(0.5f);

    }

    IEnumerator SetUltraModeStage()
    {
        if (gameModenum == 2)
        {
            for (int i = 0; i < ultraLevelat - 1; i++)
            {
                stages[i].SetActive(false);
                stagePass[i].SetActive(true);
                stageLock[i].SetActive(false);
                Buttons[i].interactable = true;
            }

            // 기본 상태 활성화
            stages[ultraLevelat-1].SetActive(true);
            stagePass[ultraLevelat-1].SetActive(false);
            stageLock[ultraLevelat-1].SetActive(false);
            Buttons[ultraLevelat-1].interactable = true;

            //levelat = PlayerPrefs.GetInt("levelReached"); //for(int i = levelat+1) 대신 사용
            // Lock 활성화
            for (int i = ultraLevelat; i < stages.Length; i++)
            {
                stages[i].SetActive(false);
                stagePass[i].SetActive(false);
                stageLock[i].SetActive(true);
                Buttons[i].interactable = false;
            }
        }

        yield return new WaitForSeconds(0.5f);
    }


    IEnumerator ChangeCharacterColor()
    {
        Player1_Character = PlayerPrefs.GetInt("Player1_Character",3);
        Player2_Character = PlayerPrefs.GetInt("Player2_Character",4);
        

        for (int i = 0; i < CharacterImage.Length; i++)
        {
            CharacterImage[i].color = Color.white;
        }

        

        if (PlayerCharacter[1].activeSelf == true)
        {
            CharacterImage[Player2_Character].color = Color.blue;
        }

        if (PlayerCharacter[0].activeSelf == true)
        {
            CharacterImage[Player1_Character].color = Color.red;
        }

        if(PlayerCharacter[1].activeSelf == true)


        yield return new WaitForSeconds(0.5f);
    }

    public void ClickOnCharacterHelp()
    {
        CharacterHelpUI.SetActive(true);
    }
    public void ClickOnSkullBack()
    {
        SkullUI.SetActive(false);
    }

    public void ClickOnAstroBack()
    {
        AstroUI.SetActive(false);
    }

    public void ClickOnSettingButton()
    {
        soundEffectAudioPlayer.PlayOneShot(clickClip);
        settingUI_Start.SetActive(true);
        StartStageUI.SetActive(false);
        
    }

    public void ClickOnSettingBack()
    {
        soundEffectAudioPlayer.PlayOneShot(clickClip);
        StartStageUI.SetActive(true);
        settingUI_Start.SetActive(false);
    }

    public void ClickOnHome()
    {
        soundEffectAudioPlayer.PlayOneShot(clickClip);
        SceneManager.LoadScene("Lobby");
        //LoadingSceneManager.LoadScene("Lobby");
    }

    public void ClickOnStageUp()
    {
        StartCoinCount++;
        soundEffectAudioPlayer.PlayOneShot(clickClip);
        StartStageUI.SetActive(false);
        LastStageUI.SetActive(true);
    }

    public void ClickOnStageDown()
    {
        StartCoinCount++;
        soundEffectAudioPlayer.PlayOneShot(clickClip);
        LastStageUI.SetActive(false);
        StartStageUI.SetActive(true);
    }

    public void ClickOnCharacter()
    {
        //isCharacterRepeat = PlayerPrefs.GetInt("isCharaterRepeat", 0);
        soundEffectAudioPlayer.PlayOneShot(clickClip);
        StartStageUI.SetActive(false);
        CharacterUI.SetActive(true);
        if (easyLevelat == 1 && hardLevelat == 1 && ultraLevelat == 1)
        {
            if (isCharacterRepeat == 0)
            {
                CharacterHelpUI.SetActive(true);
                PlayerPrefs.SetInt("isCharacterRepeat", 1);
                
            }

        }
    }

    void isCharacterSet()
    {
        StartStageUI.SetActive(false);
        CharacterUI.SetActive(true);
        if (easyLevelat == 1 && hardLevelat == 1 && ultraLevelat == 1)
        {
            if (isCharacterRepeat == 0)
            {
                CharacterHelpUI.SetActive(true);
                PlayerPrefs.SetInt("isCharacterRepeat", 1);

            }

        }
    }

    public void ClickOnCharacterBack()
    {
        soundEffectAudioPlayer.PlayOneShot(clickClip);
        CharacterUI.SetActive(false);
        StartStageUI.SetActive(true);
    }

    public void ClickOnDifficulty()
    {
        DifficultyCoinCount++;
    }

    public void ClickOnPlayer1()
    {
        soundEffectAudioPlayer.PlayOneShot(playerSelectClip);
        isPlayer1 = true;
        isPlayer2 = false;
        
        
    }

    public void ClickOnPlayer2()
    {
        soundEffectAudioPlayer.PlayOneShot(playerSelectClip);
        isPlayer1 = false;
        isPlayer2 = true;
        
       
    }


    public void ClickOnCharacterImage0()
    {
        int a = 0;
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);

        if (isPlayer1 ==true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
            
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
            
        }

        

        
    }

    public void ClickOnCharacterImage1()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);

        int a = 1;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }

        

    }

    public void ClickOnCharacterImage2()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);

        int a = 2;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }



    }

    public void ClickOnCharacterImage3()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);

        int a = 3;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }



    }

    public void ClickOnCharacterImage4()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);

        int a = 4;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }



    }

    public void ClickOnCharacterImage5()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);

        int a = 5;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }



    }

    public void ClickOnCharacterImage6()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);

        int a = 6;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }



    }

    public void ClickOnCharacterImage7()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);

        int a = 7;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }



    }

    public void ClickOnCharacterImage8()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);

        int a = 8;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }


        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }



    }

    public void ClickOnCharacterImage9()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);

        int a = 9;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }
    }

    public void ClickOnCharacterImage10()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);

        int a = 10;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }
    }

    public void ClickOnCharacterImage11()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);
        int a = 11;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }
    }

    public void ClickOnCharacterImage12()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);
        int a = 12;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }
    }

    public void ClickOnCharacterImage13()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);
        int a = 13;
        if (isPlayer1 == true)
        {

            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }
    }

    public void ClickOnCharacterImage14()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);

        int a = 14
;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }
    }

    public void ClickOnCharacterImage15()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);
        int a = 15;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }
    }

    public void ClickOnCharacterImage16()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);
        int a = 16;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }
    }

    public void ClickOnCharacterImage17()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);
        int a = 17;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }
    }

    public void ClickOnCharacterImage18()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);
        int a = 18;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }
    }

    public void ClickOnCharacterImage19()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);
        int a = 19;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }
    }

    public void ClickOnCharacterImage20()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);
        int a = 20;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }
    }

    public void ClickOnCharacterImage21()
    {
        soundEffectAudioPlayer.PlayOneShot(characterSelectClip);
        int a = 21;
        if (isPlayer1 == true)
        {
            PlayerPrefs.SetInt("Player1_Character", a);
        }

        if (isPlayer2 == true)
        {
            PlayerPrefs.SetInt("Player2_Character", a);
        }
    }

    public void SetCoinText()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
        //int coinFirst = (coin / 10) % 10;
        //int coinSecond = (coin % 10);

        coinText.text = ""+ coin; //"" + coinFirst + coinSecond;
    }

    public void ClickonStage1()
    {
        //SceneManager.LoadScene("Stage1");
        LoadingSceneManager.LoadScene("new_stage1");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ClickonStage2()
    {
        LoadingSceneManager.LoadScene("new_stage2");
    }

    public void ClickonStage3()
    {
        LoadingSceneManager.LoadScene("new_stage3");
    }

    public void ClickonStage4()
    {
        LoadingSceneManager.LoadScene("new_stage4");
    }

    public void ClickonStage5()
    {
        LoadingSceneManager.LoadScene("new_stage5");
    }

    public void ClickonStage6()
    {
        LoadingSceneManager.LoadScene("new_stage6");
    }

    public void ClickonStage7()
    {
        LoadingSceneManager.LoadScene("new_stage7");
    }

    public void ClickonStage8()
    {
        LoadingSceneManager.LoadScene("new_stage8");
    }

    public void ClickonStage9()
    {
        LoadingSceneManager.LoadScene("new_stage9");
    }

    public void ClickonStage10()
    {
        LoadingSceneManager.LoadScene("new_stage10");
    }

    public void ClickonStage11()
    {
        LoadingSceneManager.LoadScene("new_stage11");
    }

    public void ClickonStageFinal()
    {
        LoadingSceneManager.LoadScene("new_Final");
    }


}
