using System.Collections;
using System.Collections.Generic;
using Anatinus.My_Scripts.Gameplay;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public bool deflected = false;
    public float originalSpeed = 10;
    public float speed;
    public float dmg;
    private enemyBulletGraphics _graphics;

    // Use this for initialization
    void Start()
    {
        _graphics = GetComponentInChildren<enemyBulletGraphics>();
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

        //Bullet when deflected w/ Sonic Pulse
        if (deflected == true)
        {
            gameObject.layer = 10; //Changes the enemy bullet into a player bullet
            _graphics.deflected = true; //Changes the graphics
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
