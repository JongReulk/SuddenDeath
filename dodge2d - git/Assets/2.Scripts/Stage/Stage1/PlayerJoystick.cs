using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D PlayerRigidbody;

    public bl_Joystick Joystick;

    private void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        //float xInput = Input.GetAxis("Horizontal");
        //float yInput = Input.GetAxis("Vertical");

        float yInput = Joystick.Vertical;
        float xInput = Joystick.Horizontal;

        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);
        // 리지드바디의 속도에 newVelocity를 할당
        PlayerRigidbody.velocity = newVelocity;


    }
}
