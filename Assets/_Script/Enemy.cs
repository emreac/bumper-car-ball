using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody enemyRb;
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 lookDirection = (ball.transform.position - transform.position).normalized;
        Vector3 lookDirection = (ball.transform.position - transform.position);
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
    }
}


