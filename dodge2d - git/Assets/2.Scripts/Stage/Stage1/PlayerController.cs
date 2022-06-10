using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    private float speed = 3f;
    private Rigidbody2D PlayerRigidbody;
    private bl_Joystick Joystick;
    public bl_Joystick Joystick_L;
    public bl_Joystick Joystick_R;
    public GameObject Joystick_L_Active;
    public GameObject Joystick_R_Active;
    private string Player1_Joystick;




    private void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();

        StartCoroutine("JoystickControl");

        Player1_Joystick = PlayerPrefs.GetString("Player1_Joystick", "R");


    }
    // Update is called once per frame
    void Update()
    {
        if(UIManager.instance.isPaused)
        {
            PlayerRigidbody.velocity = new Vector2(0, 0);
        }
        

        //Joystick = Joystick_L;
        float yInput = Joystick.Vertical;
        float xInput = Joystick.Horizontal;

        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);
        
        PlayerRigidbody.velocity = newVelocity;
    }

    IEnumerator JoystickControl()
    {
        yield return new WaitForSeconds(0.3f);

        if (Joystick_L_Active.activeSelf == true)
        {
            Joystick = Joystick_L;
        }

        if (Joystick_R_Active.activeSelf == true)
        {
            Joystick = Joystick_R;
        }

    }


    private void Die()
    {

        gameObject.SetActive(false);

        GameManager.instance.EndGame();

        
    }
}
