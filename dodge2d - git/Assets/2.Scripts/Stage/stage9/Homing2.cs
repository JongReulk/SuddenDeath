using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing2 : MonoBehaviour
{
    private Transform Target1;
    private Transform Target2;
    private float MoveSpeed = 385f;
    private float RotateSpeed = 2000f;

    private int playernum;
    private float StartTime = 4f;
    public GameObject player1_ho_2;
    public GameObject player2_ho_2;
    private float[] homings = new float[2];
    private Rigidbody2D Homingrb;
    private float HomingTime2;




    private void Awake()
    {


    }
    // Use this for initialization
    void Start()
    {
        playernum = PlayerPrefs.GetInt("Playernum");

        Target1 = GameObject.FindWithTag("PLAYER1").transform;

        if (playernum == 2)
        {
            Target2 = GameObject.FindWithTag("PLAYER2").transform;
        }
        HomingTime2 = 0;


        Homingrb = GetComponent<Rigidbody2D>();
        Homingrb.gravityScale = 0;
        Homingrb.velocity = Vector2.zero;



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //print("Homing :" + Time.time);
        HomingTime2 += Time.deltaTime;
        //print("Homing Start :" + StartTime);
        if (HomingTime2 > StartTime)
        {
            if (playernum == 1)
            {
                Homingrb.velocity = transform.up * MoveSpeed * Time.fixedDeltaTime;


                Vector3 targetVector = Target1.position - transform.position;

                float rotatingIndex = Vector3.Cross(targetVector, transform.up).z;

                Homingrb.angularVelocity = -1 * rotatingIndex * RotateSpeed * Time.fixedDeltaTime;
            }

            if (playernum == 2)
            {

                Homingrb.velocity = transform.up * MoveSpeed * Time.fixedDeltaTime;

                Vector3 targetVector1 = Target1.position - transform.position;
                Vector3 targetVector2 = Target2.position - transform.position;

                float rotatingIndex1 = Vector3.Cross(targetVector1, transform.up).z;
                float rotatingIndex2 = Vector3.Cross(targetVector2, transform.up).z;
                homings[0] = rotatingIndex1;
                homings[1] = rotatingIndex2;

                int randomHoming = Random.Range(0, homings.Length);
                float homingChosen = homings[randomHoming];

                Homingrb.angularVelocity = -1 * homingChosen * RotateSpeed * Time.fixedDeltaTime;
            }
        }



        if (!player1_ho_2.activeInHierarchy)
        {
            Target1 = Target2;
        }

        if (!player2_ho_2.activeInHierarchy)
        {
            Target2 = Target1;
        }
        if (!player2_ho_2.activeInHierarchy && !player1_ho_2.activeInHierarchy)
        {
            this.gameObject.SetActive(false);
        }
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

            //gameObject.SetActive(false);

        }
    }
}
