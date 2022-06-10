using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    private bool lobbyExit = false;
    private bool lobbyisExit = false;
    private int lobbyHeaderClick = 0;
    private int lobbyHeaderCoin;
    private int coin;
    private bool isDone = false;
    private bool isLobbyHelp = false;
    private bool isPlayerHelp = false;


    public GameObject coinEgg;

    [Header("UI")]
    public GameObject lobbySettingUI;
    public GameObject lobbyUI;
    public GameObject playerUI;
    public GameObject HelpUI;
    public GameObject PlayerHelpUI;


    [Header("Music")]
    private AudioSource LobbyAudio;
    public AudioClip lobbyClickClip;
    public AudioClip lobbybuttonClip;
    public AudioClip lobbyCoinClip;
    

    // Start is called before the first frame update
    void Start()
    {
        lobbyisExit = false;
        LobbyAudio = GetComponent<AudioSource>();
        lobbyHeaderCoin = PlayerPrefs.GetInt("lobbyHeaderCoin", 0);
        coin = PlayerPrefs.GetInt("Coin",0);
    }

    // Update is called once per frame
    void Update()
    {
        if (lobbyHeaderCoin == 0)
        {
            if (lobbyHeaderClick == 10)
            {
                if (!isDone)
                {
                    coin = coin + 3;
                    PlayerPrefs.SetInt("Coin", coin);
                    PlayerPrefs.SetInt("lobbyHeaderCoin", 1);
                    StartCoroutine(lobbyCoinSet());
                    isDone = true;
                }
            }
        }
   
    }

    IEnumerator lobbyCoinSet()
    {
        coinEgg.SetActive(true);
        LobbyAudio.PlayOneShot(lobbyCoinClip);
        yield return new WaitForSeconds(2f);
        coinEgg.SetActive(false);
    }
    public void LobbyClickOnStart()
    {
        LobbyAudio.PlayOneShot(lobbybuttonClip);
        //SceneManager.LoadScene("Player");
        playerUI.SetActive(true);
        lobbyUI.SetActive(false);
    }

    public void LobbyClickOnSetting()
    {
        LobbyAudio.PlayOneShot(lobbybuttonClip);
        lobbySettingUI.SetActive(true);

    }

    public void LobbyClickOnSettingBack()
    {
        LobbyAudio.PlayOneShot(lobbyClickClip);
        lobbySettingUI.SetActive(false);
    }

    public void LobbyClickExit()
    {
        LobbyAudio.PlayOneShot(lobbybuttonClip);
        lobbyisExit = true;
        Application.Quit();
        Debug.Log("Game Exit");
    }


    public void ClickOnPlayerBack()
    {
        LobbyAudio.PlayOneShot(lobbyClickClip);
        //SceneManager.LoadScene("Lobby");
        playerUI.SetActive(false);
        lobbyUI.SetActive(true);
    }

    public void ClickOnLobbyHeader()
    {
        lobbyHeaderClick++;
        print(lobbyHeaderClick);
    }

    public void ClickOnLobbyHelp()
    {
        isLobbyHelp = true;

        PlayerPrefs.SetInt("Help", 1);
        HelpUI.SetActive(true);
    }

    public void ClickOnPlayerHelp()
    {

        PlayerPrefs.SetInt("Help", 1);
        PlayerHelpUI.SetActive(true);
    }
}
