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
        float x = Random.Range(-25f, 25f);
        float z = Random.Range(-30f, 25f);
        Instantiate(myPrefab, new Vector3(x, 0.60f, z), Quaternion.identity);
    }
}
