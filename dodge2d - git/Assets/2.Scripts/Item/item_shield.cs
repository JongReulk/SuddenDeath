using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_shield : MonoBehaviour
{
    private float speed = 25f;
    //private float speed;
    private Rigidbody2D bulletRigidbody;
    private Rigidbody2D TestRigidbody;
    private int gameModenum;
    private int colliderCount;
    private int isShield;

    Collider2D m_collider;

    // Start is called before the first frame update
    void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<CircleCollider2D>();

        

        colliderCount = 0;
        //bulletRigidbody.velocity = transform.right * speed;

        //StartCoroutine(Destroybullet());
    }

    private void Start()
    {
        isShield = PlayerPrefs.GetInt("isShield", 0);
    }




    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PLAYER1")
        {
            Debug.Log("Shield Player 1OK");


            PlayerPrefs.SetInt("isShield", 1);
            GameManager.instance.isShieldItem = true;

            gameObject.SetActive(false);

            //StartCoroutine(GetShield());


            //GameManager.instance.EndGame();
            //GameObject.FindWithTag("PLAYER1").SendMessage("Die");

        }

        if (other.gameObject.tag == "PLAYER2")
        {
            Debug.Log("Shield Player 2 OK");


            PlayerPrefs.SetInt("isShield", 1);
            GameManager.instance.isShieldItem = true;

            gameObject.SetActive(false);
            //StartCoroutine(GetShield());


            //stageCoin.Play();


            //GameManager.instance.EndGame();
            //GameObject.FindWithTag("PLAYER2").SendMessage("Die");

        }

        if (other.gameObject.tag == "MainCamera")
        {
            colliderCount++;
            //gameObject.SetActive(false);

        }

        if (other.gameObject.tag == "BounceBullet")
        {


        }

        if (other.gameObject.tag == "OBSTACLE")
        {
            colliderCount++;
            //gameObject.SetActive(false);

        }
        /*
        if (colliderCount == 3)
        {
            colliderCount = 0;
            gameObject.SetActive(false);
        }*/
    }

    private void FixedUpdate()
    {
        //bulletRigidbody.velocity = transform.right * speed * Time.fixedDeltaTime;

    }

    public void OnEnable()
    {
        gameModenum = PlayerPrefs.GetInt("gameMode");

        if (gameModenum == 1)
        {
            speed = 408f;
        }

        if (gameModenum == 2)
        {
            speed = 510f;
        }

        if (gameModenum == 0)
        {
            speed = 340f;
        }

        bulletRigidbody.velocity = transform.right * speed * Time.fixedDeltaTime;

        //transform.Translate(Vector2.right);

        StartCoroutine(DisableBullet());


    }

    public void OnDisable()
    {


    }

    IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(7.0f);

        gameObject.SetActive(false);
    }

    IEnumerator GetShield()
    {

        PlayerPrefs.SetInt("isShield", 1);

        yield return new WaitForSeconds(3.0f);

        PlayerPrefs.SetInt("isShield", 0);

        gameObject.SetActive(false);
    }

    void SetStageCoin()
    {

    }
}
