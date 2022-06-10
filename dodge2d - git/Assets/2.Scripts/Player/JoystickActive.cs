using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickActive : MonoBehaviour
{
    public GameObject[] joystickNum;
    private int playernum;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        playernum = PlayerPrefs.GetInt("Playernum");
        if(playernum == 2)
        {
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
