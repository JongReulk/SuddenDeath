using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadObstacle : MonoBehaviour
{
    
    private Rigidbody2D obstacleRigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        //obstacleRigidbody = GetComponent<Rigidbody2D>();
        //bulletRigidbody.velocity = transform.right * speed;

        //StartCoroutine(Destroybullet());
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PLAYER1")
        {
            Debug.Log("OK");

            //GameManager.instance.EndGame();
            GameObject.FindWithTag("PLAYER1").SendMessage("Die");

        }

        if (other.tag == "PLAYER2")
        {
            Debug.Log("OK");

            //GameManager.instance.EndGame();
            GameObject.FindWithTag("PLAYER2").SendMessage("Die");

        }

    }
}
