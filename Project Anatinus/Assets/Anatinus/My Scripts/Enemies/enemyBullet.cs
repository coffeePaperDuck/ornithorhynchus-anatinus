using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public bool deflected = false;
    public float originalSpeed = 10;
    public float speed;
    public float dmg;

    // Use this for initialization
    void Start()
    {
        speed = originalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Despawn bullet if it goes off the screen
        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 7.5 || transform.position.y < -7.5)
        {
            Destroy(gameObject);
        }

        //Bullet movement
        transform.Translate(0, 0, speed * Time.deltaTime);

        //Bullet graphics
        enemyBulletGraphics graphics = GetComponentInChildren<enemyBulletGraphics>();

        //Bullet when deflected w/ Sonic Pulse
        if (deflected == true)
        {
            gameObject.layer = 10; //Changes the enemy bullet into a player bullet
            graphics.deflected = true; //Changes the graphics
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(dmg);
            Destroy(gameObject);
        }
    }
}
