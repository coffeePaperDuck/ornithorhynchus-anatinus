using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;


public class playerBullets : MonoBehaviour
{
    public float speed = 20.0f;
    public float vertSpeed;
    public float zSpeed;
    public float timer = 1.0f;
    public float rotation;
    public float dmg;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, vertSpeed * Time.deltaTime, zSpeed * Time.deltaTime);
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

        if (transform.position.z > 0)
        {
            zSpeed = -1f;
        }
        if (transform.position.z < 0)
        {
            zSpeed = 1f;
        }
    }

    //Collisions
    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();
        powerupStar powerup = hit.GetComponent<powerupStar>();

        //if it has health, then taketh away (and despawn bullet)
        if (health != null)
        {
            health.TakeDamage(dmg);
            Debug.Log(dmg + " this is 'dmg', from the bullet script");
            /*LeanPool.*/
            Destroy(gameObject);
        }

        //if it is a powerup, then power it up (and despawn bullet)
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
