using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private float speed = 160f;
    private Rigidbody2D PlayerRigidbody;
    
    
    [Header("Joystick")]
    private bl_Joystick Joystick;
    public bl_Joystick Joystick_L_2;
    public bl_Joystick Joystick_R_2;

    private int isShield;
    private bool isRepeat;
    private bool isgetShield;


    private string Player2_Joystick;

    public GameObject Shield_2;

    [Header("Character")]
    public GameObject[] PlayerCharacter_2;
    private int Player2;


    private void Start()
    {

        PlayerRigidbody = GetComponent<Rigidbody2D>();

        //StartCoroutine("JoystickControl");

        Player2_Joystick = PlayerPrefs.GetString("Player2_Joystick","R");

        Player2 = PlayerPrefs.GetInt("Player2_Character",4);

        PlayerPrefs.SetInt("isShield", 0);


        for (int i = 0; i < PlayerCharacter_2.Length; i++)
        {
            PlayerCharacter_2[i].SetActive(false);
        }
        

        
        PlayerCharacter_2[Player2].SetActive(true);
        print(Player2);
        
        


        

        
        if (Player2_Joystick == "L")
        {
            Joystick = Joystick_L_2;
            Debug.Log("p2L");
        }

        if (Player2_Joystick == "R")
        {
            Joystick = Joystick_R_2;
            Debug.Log("p2R");
        }
        

        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        isShield = PlayerPrefs.GetInt("isShield", 0);

        if (isShield == 1)
        {
            if (!isRepeat)
            {
                StartCoroutine(GetShield());
                isRepeat = true;
            }

        }

        if (UIManager.instance.isPaused)
        {
            PlayerRigidbody.velocity = new Vector2(0, 0);
        }
        Vector3 characterScale = transform.localScale;

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
        yield return new WaitForSeconds(0.5f);

        if (Player2_Joystick == "L")
        {
            Joystick = Joystick_L_2;
            Debug.Log("p2L");
        }

        if (Player2_Joystick == "R")
        {
            Joystick = Joystick_R_2;
            Debug.Log("p2R");
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
        Shield_2.SetActive(true);

        Debug.Log("Shied!!!!");

        yield return new WaitForSeconds(3.0f);

        Shield_2.SetActive(false);
        PlayerPrefs.SetInt("isShield", 0);
        isgetShield = false;
        isRepeat = false;


    }
}
