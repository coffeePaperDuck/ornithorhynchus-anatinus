using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPulse : MonoBehaviour
{
    public float speed = 20.0f;
    public float dmg;
    public float timer = 1.0f;

    public float colliderTimer;
    Collider m_Collider;

    // Use this for initialization
    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.localScale += new Vector3(10f * Time.deltaTime, 10f * Time.deltaTime, 10f * Time.deltaTime);

        timer -= 3.0f * Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
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
        enemyBullet deflectBullet = hit.GetComponent<enemyBullet>();
        enemyLaser deflectLaser = hit.GetComponent<enemyLaser>();

        if (health != null)
        {
            health.TakeDamage(dmg);
        }

        if (powerup != null)
        {
            if (powerup.timer < 0.3)
            {
                powerup.powerup += 0.01f;
            }
        }

        if (deflectBullet != null)
        {
            deflectBullet.deflected = true;
            deflectBullet.speed -= deflectBullet.originalSpeed * 1.7f;
            deflectBullet.dmg = deflectBullet.dmg * 2;
        }

        if (deflectLaser != null)
        {
            deflectLaser.deflected = true;
            deflectLaser.speed -= deflectLaser.originalSpeed * 1.7f;
            deflectLaser.dmg = deflectLaser.dmg * 2;
        }
    }

    void OnDisable()
    {
        transform.localScale = new Vector3(0, 0, 0);
        timer = 1.0f;
    }
}
