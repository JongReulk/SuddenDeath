using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadedBullet : MonoBehaviour
{
    private float speed = 400f;
    //private float speed;
    private Rigidbody2D bulletRigidbody;
    private int gameModenum;
    private Color color;
    private SpriteRenderer bulletSprite;
    private CircleCollider2D bulletCollider;

    //private Color bulletSprite;

    // Start is called before the first frame update
    void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        //bulletRigidbody.velocity = transform.right * speed;
        bulletSprite = GetComponent<SpriteRenderer>();
        color = bulletSprite.color;
        bulletCollider = GetComponent<CircleCollider2D>();
        //StartCoroutine(Destroybullet());
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MainCamera")
        {

            gameObject.SetActive(false);

        }

        
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

    private void FixedUpdate()
    {
        bulletRigidbody.velocity = transform.right * speed * Time.deltaTime;
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

        //transform.Translate(Vector2.right);

        StartCoroutine("bulletAlphaChange");


    }

    public void OnDisable()
    {
        transform.position = Vector2.zero;
        transform.rotation = Quaternion.identity;
        bulletRigidbody.velocity = Vector2.zero;
        color.a = 1f;
        bulletSprite.color = color;

    }

    IEnumerator bulletAlphaChange()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            color.a = 0.1f;
            bulletSprite.color = color;
            

            yield return new WaitForSeconds(0.5f);
            
            color.a = 1f;
            bulletSprite.color = color;
        }
        
    }
}
