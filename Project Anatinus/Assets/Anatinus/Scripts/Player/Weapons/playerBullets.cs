using System.Collections;
using System.Collections.Generic;
using Anatinus.My_Scripts.Gameplay;
using UnityEngine;


public class playerBullets : MonoBehaviour
{
    private float _timeSpeed = 1;
    private float _time = 0.2f;

    public bool wide;
    public float xSpeed = 20.0f;
    public float ySpeed;
    public float zSpeed;
    public float rotation;

    public float dmg;

    void Update()
    {
        var dt = Time.deltaTime;
        transform.Translate(xSpeed*dt, ySpeed*dt, zSpeed*dt);
        transform.eulerAngles = new Vector3(0, 0, rotation);

        _time -= _timeSpeed*dt;
        if (_time < 0)
        { transform.Translate(0, -ySpeed*dt, 0); }

        if (transform.position.z > 0)
        { zSpeed = -1; }
        if (transform.position.z < 0)
        { zSpeed = 1; }
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

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnDisable()
    {
        _time = 1.0f;
    }
}
