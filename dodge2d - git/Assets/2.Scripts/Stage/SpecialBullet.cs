using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    private float speed = 400f;
    //private float speed;
    private Rigidbody2D bulletRigidbody;
    private int gameModenum;
    Vector2 maxScale = new Vector2(0.8f, 0.8f);
    Vector2 minScale = new Vector2(0.4f, 0.4f);
    Vector3 maxScale2 = new Vector3(1.2f, 1.2f,0);

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
        transform.localScale = Vector2.Lerp(transform.localScale, maxScale, Time.deltaTime);

    }

    public void OnEnable()
    {
        gameModenum = PlayerPrefs.GetInt("gameMode");

        if (gameModenum == 1)
        {
            speed = 360f;
        }

        if (gameModenum == 2)
        {
            speed = 450f;
        }

        if (gameModenum == 0)
        {
            speed = 300f;
        }

        //bulletRigidbody.velocity = transform.right * speed;
        //bulletRigidbody.velocity = transform.right * speed;
        //transform.Translate(Vector2.right);

        
        //StartCoroutine("bulletScaleChange");

    }



    public void OnDisable()
    {
        transform.position = Vector2.zero;
        transform.rotation = Quaternion.identity;
        bulletRigidbody.velocity = Vector2.zero;
        transform.localScale = minScale;
    }

    IEnumerator bulletScaleChange()
    {
        while (true)
        {
            
        }

    }

    /*IEnumerator Destroybullet()
    {
        yield return new WaitForSeconds(4.0f);

        gameObject.SetActive(false);
    }*/
}
