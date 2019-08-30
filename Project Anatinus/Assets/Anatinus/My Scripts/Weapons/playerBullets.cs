using System.Collections;
using System.Collections.Generic;
using Anatinus.My_Scripts.Gameplay;
using UnityEngine;


public class playerBullets : MonoBehaviour
{
    public float xSpeed = 20.0f;
    public float ySpeed;
    public float zSpeed;

    public float timer = 1.0f;
    public float rotation;
    public float dmg;

    void Update()
    {
        Transform transform1;
        (transform1 = transform).Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
        transform1.eulerAngles = new Vector3(0, 0, rotation);

        timer -= 5.0f * Time.deltaTime;
        if (timer < 0)
        {
            transform.Translate(0, -ySpeed * Time.deltaTime, 0);
        }

        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 7.5 || transform.position.y < -7.5)
        {
            Destroy(gameObject);
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
            Destroy(gameObject);
        }

        //if it is a powerup, then power it up (and despawn bullet)
        if (powerup != null)
        {
            if (powerup.timer < 0.3)
            {
                powerup.powerup += 0.01f;
                Destroy(gameObject);
            }
        }
    }

    void OnDisable()
    {
        timer = 1.0f;
    }
}
