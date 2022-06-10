using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    private Transform Target1;
    private Transform Target2;
    float MoveSpeed = 1200f;
    float RotateSpeed = 2000f;
    private Rigidbody2D Missilerb;
    public GameObject player1_mi;
    public GameObject player2_mi;
    private int playernum;
    private int gameModenum;
    private float[] targets = new float[2];

    private void Start()
    {
        Missilerb = GetComponent<Rigidbody2D>();
        Missilerb.gravityScale = 0;

        playernum = PlayerPrefs.GetInt("Playernum");
        if (playernum == 2)
            Target1 = GameObject.FindWithTag("PLAYER1").transform;
        Target2 = GameObject.FindWithTag("PLAYER2").transform;
        gameModenum = PlayerPrefs.GetInt("gameMode");

        if (gameModenum == 1)
        {
            MoveSpeed = 1440f;
        }

        if (gameModenum == 2)
        {
            MoveSpeed = 1600f;
        }

        if (gameModenum == 0)
        {
            MoveSpeed = 1200f;
        }
    }

    private void Update()
    {

        StartCoroutine(missileAttack());
    }


    IEnumerator missileAttack()
    {
        yield return new WaitForSeconds(1.5f);
        while (true)
        {
            
            if (!player1_mi.activeInHierarchy)
            {
                Target1 = Target2;
            }

            if (!player2_mi.activeInHierarchy)
            {
                Target2 = Target1;
            }

            Missilerb.velocity = transform.up * MoveSpeed * Time.deltaTime;

            Vector3 targetVector1 = Target1.position - transform.position;
            Vector3 targetVector2 = Target2.position - transform.position;

            float rotatingIndex1 = Vector3.Cross(targetVector1, transform.up).z;
            float rotatingIndex2 = Vector3.Cross(targetVector2, transform.up).z;

            targets[0] = rotatingIndex1;
            targets[1] = rotatingIndex2;
            int randomTarget = Random.Range(0, targets.Length);
            float targetChosen = targets[randomTarget];


            Missilerb.angularVelocity = -1 * (targetChosen) * RotateSpeed * Time.deltaTime;
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

        if (other.tag == "MISSILE")
        {

            //gameObject.SetActive(false);

        }
    }
}
