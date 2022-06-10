using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    private float speed = 160f;
    private Rigidbody2D PlayerRigidbody;
    private bl_Joystick Joystick;
    
    [Header("Joystick")]
    public bl_Joystick Joystick_L_1;
    public bl_Joystick Joystick_R_1;

    
    private string Player1_Joystick;

    private int isShield;
    private bool isRepeat;
    private bool isgetShield;

    [Header("Character")]
    public GameObject[] PlayerCharacter_1;
    private int Player1;
    public GameObject Shield_1;

    private void Awake()
    {
        isRepeat = false;
    }



    private void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();

        Player1_Joystick = PlayerPrefs.GetString("Player1_Joystick","R");

        PlayerPrefs.SetInt("isShield", 0);

        Player1 = PlayerPrefs.GetInt("Player1_Character",3);
        print(Player1);

        for (int i=0; i<PlayerCharacter_1.Length; i++)
        {
            PlayerCharacter_1[i].SetActive(false);
        }

        


        PlayerCharacter_1[Player1].SetActive(true);
        print(Player1);
        

        //StartCoroutine("JoystickControl");

        
        if (Player1_Joystick == "L")
        {
            Joystick = Joystick_L_1;
            Debug.Log("p1L");
        }

        if (Player1_Joystick == "R")
        {
            Joystick = Joystick_R_1;
            Debug.Log("p1R");
        }
        


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //StartCoroutine("JoystickControl");
        isShield = PlayerPrefs.GetInt("isShield", 0);
        
        if(isShield == 1)
        {
            if(!isRepeat)
            {
                StartCoroutine(GetShield());
                isRepeat = true;
            }
            
        }

        if (UIManager.instance.isPaused)
        {
            PlayerRigidbody.velocity = new Vector2(0, 0);
        }


        //Joystick = Joystick_L;
        float yInput = Joystick.Vertical;
        float xInput = Joystick.Horizontal;

        float xSpeed = xInput * speed * Time.deltaTime;
        float ySpeed = yInput * speed * Time.deltaTime;

        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);

        PlayerRigidbody.velocity = newVelocity;
    }

    
    
    IEnumerator JoystickControl()
    {
        yield return new WaitForSeconds(0.3f);

        if (Player1_Joystick == "L")
        {
            Joystick = Joystick_L_1;
            Debug.Log("p1L");
        }

        if (Player1_Joystick == "R")
        {
            Joystick = Joystick_R_1;
            Debug.Log("p1R");
        }

    }


    private void Die()
    {
        if (isgetShield)
        {
            return;
        }

        gameObject.SetActive(false);

        GameManager.instance.EndGame();

    }

    IEnumerator GetShield()
    {
        isgetShield = true;
        Shield_1.SetActive(true);

        Debug.Log("Shied!!!!");

        yield return new WaitForSeconds(3.0f);

        Shield_1.SetActive(false);
        PlayerPrefs.SetInt("isShield", 0);
        isgetShield = false;
        isRepeat = false;


    }
}
