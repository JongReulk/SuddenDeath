using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public GameObject[] gameMode;
    public GameObject EasyMode, hardMode, ultraMode;

    [Header("SoundEffect")]
    private AudioSource gameModeAudio;
    public AudioClip gameModeClip;

    int gameModenum;

    private void Awake()
    {
        gameModenum = PlayerPrefs.GetInt("gameMode", 0);
    }

    // Start is called before the first frame update

    void Start()
    {
        //gameModenum = 0;
        gameMode[gameModenum].SetActive(true);
        gameModeAudio = GetComponent<AudioSource>();
        
    }


    public void SwitchAvatar()
    {
        switch (gameModenum)
        {
            case (0):

                gameModenum = 1;

                gameModeAudio.PlayOneShot(gameModeClip);

                EasyMode.gameObject.SetActive(false);
                hardMode.gameObject.SetActive(true);
                ultraMode.gameObject.SetActive(false);

                Debug.Log("게임모드 " + gameModenum);
                PlayerPrefs.SetInt("gameMode", gameModenum);

                //PlayerPrefs.GetInt("gameMode", gameModenum);

                break;

            case 1:

                gameModenum = 2;

                gameModeAudio.PlayOneShot(gameModeClip);

                EasyMode.gameObject.SetActive(false);
                hardMode.gameObject.SetActive(false);
                ultraMode.gameObject.SetActive(true);

                Debug.Log("게임모드 " + gameModenum);
                PlayerPrefs.SetInt("gameMode", gameModenum);
                break;

            case 2:

                gameModenum = 0;

                gameModeAudio.PlayOneShot(gameModeClip);

                EasyMode.gameObject.SetActive(true);
                hardMode.gameObject.SetActive(false);
                ultraMode.gameObject.SetActive(false);

                Debug.Log("게임모드 " + gameModenum);
                PlayerPrefs.SetInt("gameMode", gameModenum);
                break;
        }
    }
}
