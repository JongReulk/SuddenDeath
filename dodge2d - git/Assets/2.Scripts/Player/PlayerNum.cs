using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNum : MonoBehaviour
{
    private int playernum;
    private AudioSource playerAudio;
    public AudioClip ClickClip;
    private void Awake()
    {
        playernum = PlayerPrefs.GetInt("Playernum", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ClickOnOnePlayer()
    {
        playerAudio.PlayOneShot(ClickClip);
        PlayerPrefs.SetInt("Playernum", 1);
        SceneManager.LoadScene("Start");
        
    }

    public void ClickOnTwoPlayer()
    {
        playerAudio.PlayOneShot(ClickClip);
        PlayerPrefs.SetInt("Playernum", 2);
        SceneManager.LoadScene("Start");
    }

}
