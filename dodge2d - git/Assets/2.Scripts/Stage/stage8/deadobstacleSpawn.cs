using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadobstacleSpawn : MonoBehaviour
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

        if (other.tag == "MainCamera")
        {

            gameObject.SetActive(false);

        }
    }

    private void FixedUpdate()
    {
        bulletRigidbody.velocity = transform.right * speed * Time.deltaTime;
    }
    public void OnEnable()
    {
        gameModenum = PlayerPrefs.GetInt("gameMode");

        if (gameModenum == 1)
        {
            speed = 240f;
        }

        if (gameModenum == 2)
        {
            speed = 300f;
        }

        if (gameModenum == 0)
        {
            speed = 200f;
        }

        
        //bulletRigidbody.velocity = transform.right * speed;
        //transform.Translate(Vector2.right);

        //StartCoroutine(Destroybullet());
        StartCoroutine(DisableBullet());

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
