using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f; // 최소 생성주기
    public float spawnRateMax = 3f; // 최대 생성주기
    

    private Transform target1; // 발사 대상
    private Transform target2; // 발사 대상
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간
    private float StartTime = 1.5f;
    private int playernum;
    private List<Vector3> dirs;
    private float[] angles = new float[2];

    public GameObject player1;
    public GameObject player2;
    public GameObject BottomSpawnPlace;
    public GameObject[] BottomSpawnChild;


    private int gameModenum;



    //private float angle1 = 0f;
    //private float angle2 = 0f;



    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;

        playernum = PlayerPrefs.GetInt("Playernum");

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);



        gameModenum = PlayerPrefs.GetInt("gameMode");

        if (gameModenum == 1)
        {
            SetBottomSpawnPlace(true);
        }

        if (gameModenum == 2)
        {
            SetBottomSpawnPlace(true);
            SetBottomSpawnChild(true);
        }
        
        target1 = GameObject.FindWithTag("PLAYER1").transform;

        if(playernum == 2)
            target2 = GameObject.FindWithTag("PLAYER2").transform;
        
    }
    

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(Time.time > StartTime && !GameManager.instance.isGameover)
        {
            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0f;

                Shoot();
                
                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
        }

        if (!player1.activeInHierarchy)
        {
            target1 = target2;
        }

        if (!player2.activeInHierarchy)
        {
            target2 = target1;
        }

    }

    void Shoot()
    {
        var _bullet = GameManager.instance.GetBullet();
        

        var dir1 = target1.position - transform.position;
        var dir2 = target2.position - transform.position;
        float angle1 = Mathf.Atan2(dir1.y, dir1.x) * Mathf.Rad2Deg;
        float angle2 = Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg;

        angles[0] = angle1;
        angles[1] = angle2;

        
        if (_bullet != null)
        {
            if (playernum == 1)
            {
                _bullet.transform.position = transform.position;
                _bullet.transform.rotation = transform.rotation;
                _bullet.transform.rotation = Quaternion.AngleAxis(angle1, Vector3.forward);
                _bullet.SetActive(true);
            }

            if (playernum == 2)
            {
                int randomAngle = Random.Range(0, angles.Length);
                float angleChosen = angles[randomAngle];
                
                _bullet.transform.position = transform.position;
                _bullet.transform.rotation = transform.rotation;
                _bullet.transform.rotation = Quaternion.AngleAxis(angleChosen, Vector3.forward);
                _bullet.SetActive(true);


            }
        }
        else
        {
            Debug.Log("There's no bullet");
        }
    }

    void SetBottomSpawnPlace(bool active)
    {
        BottomSpawnPlace.SetActive(active);
    }

    void SetBottomSpawnChild(bool active)
    {
        for (int i = 0; i < BottomSpawnChild.Length; i++)
        {
            BottomSpawnChild[i].SetActive(active);
        }
    }
}
