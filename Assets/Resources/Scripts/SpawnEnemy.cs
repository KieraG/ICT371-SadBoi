using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private float nextActionTime = 10.0f;
    public float period = 10.0f;
    public GameObject myPrefab;

    private void Start()
    {
        InvokeRepeating("SpawnEnemyBall", 10.0f, 10.0f);
    }

    void Update()
    {
        //if (Time.time > nextActionTime)
        //{
        //    nextActionTime += period;
            
        //}
    }

    void SpawnEnemyBall()
    {
        Instantiate(myPrefab, new Vector3(-16.89f, 0.60f, 22.02f), Quaternion.identity);
    }
}
