using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileSpawner : MonoBehaviour
{
    
    private float spawnRateMin = 1f; // 최소 생성주기
    private float spawnRateMax = 4f; // 최대 생성주기


    private Transform target1; // 발사 대상
    private Transform target2; // 발사 대상
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간
    private float StartTime = 1.5f;
    private int playernum;
    private List<Vector3> dirs;
    private float[] angles = new float[2];

    

    


    
}