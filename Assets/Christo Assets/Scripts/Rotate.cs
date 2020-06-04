using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    private float accumulator = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        accumulator += speed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0.0f, accumulator, 0.0f);
    }
}
