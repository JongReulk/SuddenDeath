using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Spawner : MonoBehaviour
{
    public float spawnRateMin_it = 9f; // 최소 생성주기
    public float spawnRateMax_it = 12f; // 최대 생성주기


    private Transform target1; // 발사 대상
    private Transform target2; // 발사 대상
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간
    private float StartTime = 1.5f;
    private int playernum;
    private List<Vector3> dirs;
    private float[] angles = new float[2];

    //public GameObject Item_target1;
    //public GameObject Item_target2;

    public GameObject Item_coin;
    public GameObject Item_time;
    public GameObject Item_shield;
    private GameObject[] ItemPrefabs = new GameObject[3];
    
    private int randomItem;




    //private float angle1 = 0f;
    //private float angle2 = 0f;



    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;

        playernum = PlayerPrefs.GetInt("Playernum");

        spawnRate = Random.Range(spawnRateMin_it, spawnRateMax_it);






        //target1 = FindObjectOfType<PlayerController>().transform;
        target1 = GameObject.FindWithTag("ITEMTARGET1").transform;

        target2 = GameObject.FindWithTag("ITEMTARGET2").transform;


        ItemPrefabs[0] = Item_coin;
        ItemPrefabs[1] = Item_time;
        ItemPrefabs[2] = Item_shield;
        //angles.Add(angle1);
        //angles.Add(angle2);





    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (Time.time > StartTime && !GameManager.instance.isGameover)
        {
            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0f;

                Shoot();


                /*GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                var dir = target.position - transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/


                //_bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                //bullet.transform.LookAt(target);

                spawnRate = Random.Range(spawnRateMin_it, spawnRateMax_it);
            }
        }

        

    }

    void Shoot()
    {
        randomItem = Random.Range(0, ItemPrefabs.Length);
        Debug.Log("Random" + randomItem);
        GameObject ChosenItem = ItemPrefabs[randomItem];

        //var _bullet = GameManager.instance.GetObstacle();
        //var dir1 = target1.position - transform.position;
        //var dir2 = target2.position - transform.position;
        //var angle1 = Mathf.Atan2(dir1.y, dir1.x) * Mathf.Rad2Deg;
        //var angle2 = Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg;

        var _bullet = Instantiate(ChosenItem, transform.position, transform.rotation);
        _bullet.SetActive(false);

        var dir1 = target1.position - transform.position;
        var dir2 = target2.position - transform.position;
        float angle1 = Mathf.Atan2(dir1.y, dir1.x) * Mathf.Rad2Deg;
        float angle2 = Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg;

        angles[0] = angle1;
        angles[1] = angle2;
        int randomAngle = Random.Range(0, angles.Length);


        //int randomDir = Random.Range(0, dirs.Count - 1);
        //Vector3 dirChosen = dirs[randomDir];

        if (_bullet != null)
        {
           
            //int randomAngle = Random.Range(0, angles.Length);
            Debug.Log("랜덤 값" + randomAngle);
            float angleChosen = angles[randomAngle];

            _bullet.transform.position = transform.position;
            _bullet.transform.rotation = transform.rotation;
            _bullet.transform.rotation = Quaternion.AngleAxis(angleChosen, Vector3.forward);
            _bullet.SetActive(true);


            
        }
        else
        {
            Debug.Log("There's no bullet");
        }

        _bullet.SetActive(true);
    }
}
