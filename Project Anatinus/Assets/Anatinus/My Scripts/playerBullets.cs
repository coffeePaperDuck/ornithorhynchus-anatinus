﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Lean.Pool;


public class playerBullets : NetworkBehaviour
{
    public float speed = 20.0f;
    public float vertSpeed;
    public float timer = 1.0f;
    public float rotation;
    public float dmg;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, vertSpeed * Time.deltaTime, 0);
        transform.eulerAngles = new Vector3(0, 0, rotation);

        timer -= 5.0f * Time.deltaTime;
        if (timer < 0)
        {
            transform.Translate(0, -vertSpeed * Time.deltaTime, 0);
        }

        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 7.5 || transform.position.y < -7.5)
        {
            LeanPool.Despawn(gameObject);
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
            LeanPool.Despawn(gameObject);
        }
        if (powerup != null)
        {
            if (powerup.timer < 0.3)
            {
                powerup.powerup += 0.01f;
                LeanPool.Despawn(gameObject);
            }
        }
    }

    void OnDisable()
    {
        timer = 1.0f;
    }
}
