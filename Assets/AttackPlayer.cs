using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    Rigidbody _controller;
    Transform target;
    GameObject Player;

    [SerializeField]
    float _moveSpeed;


    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        target = Player.transform;
        _controller = GetComponent<Rigidbody>();
        _moveSpeed = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        speedIncrement();
        colorChange();
        addForce();
    }

    void speedIncrement()
    {
        _moveSpeed += Time.deltaTime / 10.0f;
    }

    void colorChange ()
    {
        
    }

    void addForce()
    {
        //Adds force towards the given player
        Vector3 direction = (target.position - transform.position);
        direction.y = 0;
        direction = direction.normalized;
        Vector3 velocity = direction * _moveSpeed;
        _controller.AddForce(velocity);
    }
}
