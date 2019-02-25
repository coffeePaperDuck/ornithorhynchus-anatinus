﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class playerRockets : NetworkBehaviour
{
    [SyncVar]
    public int lit = 0;
    [SyncVar]
    public float speed;
    [SyncVar]
    public float vertSpeed;
    [SyncVar]
    public float timer = 0.0f;
    [SyncVar]
    public float dmg;

    public Mesh rocket5Prefab;
    public Mesh rocket4Prefab;
    public Mesh rocket3Prefab;
    public Mesh rocket2Prefab;
    public Mesh rocket1Prefab;

    // Use this for initialization
    void Start()
    {
        vertSpeed = -15;
        GetComponent<MeshFilter>().mesh = rocket5Prefab;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, vertSpeed * Time.deltaTime, 0);
        transform.eulerAngles = new Vector3(0, 0, 0);

        if (lit == 1)
        {
            timer += 2.0f * Time.deltaTime;
            GetComponent<MeshFilter>().mesh = rocket4Prefab;
            vertSpeed = -7.5f;
            speed = 10;
        }

        if (timer > 0.1)
        {
            GetComponent<MeshFilter>().mesh = rocket3Prefab;
            vertSpeed = 10f;
            speed = 20;
        }

        if (timer > 0.2)
        {
            GetComponent<MeshFilter>().mesh = rocket2Prefab;
            vertSpeed = 5f;
            speed = 10;
        }

        if (timer > 0.3)
        {
            GetComponent<MeshFilter>().mesh = rocket1Prefab;
            vertSpeed = 0;
            speed = 20;
        }

        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 7.5 || transform.position.y < -7.5)
        {
            Destroy(gameObject);
        }
    }

    //Collisions
    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();
        powerupStar powerup = hit.GetComponent<powerupStar>();

        if (health != null)
        {
            health.TakeDamage(dmg);
            Destroy(gameObject);
        }
        if (powerup != null)
        {
            if (powerup.timer < 0.3)
            {
                powerup.powerup += 0.01f;
                Destroy(gameObject);
            }
        }
    }
}
