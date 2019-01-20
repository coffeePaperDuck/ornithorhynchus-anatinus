using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerBullets : MonoBehaviour
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
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(dmg);
        }

        Destroy(gameObject);
    }
}
