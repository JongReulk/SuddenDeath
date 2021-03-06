using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float speed = 240f;
    //private float speed;
    private Rigidbody2D bulletRigidbody;
    private int gameModenum;
    private int colliderCount;
    

    // Start is called before the first frame update
    void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        colliderCount = 0;
        //bulletRigidbody.velocity = transform.right * speed;

        //StartCoroutine(Destroybullet());
    }




    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "MainCamera")
        {
            colliderCount++;
            //gameObject.SetActive(false);

        }

        if (other.gameObject.tag == "BounceBullet")
        {
            colliderCount++;
            //gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "OBSTACLE")
        {
            colliderCount++;
            //gameObject.SetActive(false);
        }

        if (colliderCount == 3)
        {
            colliderCount = 0;
            gameObject.SetActive(false);
        }



    }


    public void OnEnable()
    {
        gameModenum = PlayerPrefs.GetInt("gameMode");

        if (gameModenum == 1)
        {
            speed = 288f;
        }

        if (gameModenum == 2)
        {
            speed = 360f;
        }

        if (gameModenum == 0)
        {
            speed = 240f;
        }

        bulletRigidbody.velocity = transform.right * speed * Time.fixedDeltaTime;

        
        //bulletRigidbody.velocity = transform.right * speed;
        //transform.Translate(Vector2.right);

        //StartCoroutine(Destroybullet());
        //StartCoroutine(DisableBullet());

    }

    public void OnDisable()
    {
        transform.position = Vector2.zero;
        transform.rotation = Quaternion.identity;
        bulletRigidbody.velocity = Vector2.zero;

    }

    IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(10.0f);

        gameObject.SetActive(false);
    }

    /*IEnumerator Destroybullet()
    {
        yield return new WaitForSeconds(4.0f);

        gameObject.SetActive(false);
    }*/
}
