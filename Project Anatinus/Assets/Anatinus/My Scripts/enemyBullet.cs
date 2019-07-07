using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

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
        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 7.5 || transform.position.y < -7.5)
        {
            LeanPool.Despawn(gameObject);
        }

        transform.Translate(0, 0, speed * Time.deltaTime);
        enemyBulletGraphics graphics = GetComponentInChildren<enemyBulletGraphics>();
        if (deflected == true)
        {
            gameObject.layer = 10;
            graphics.deflected = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(dmg);
            LeanPool.Despawn(gameObject);
        }
    }
}
