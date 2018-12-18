using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerBullet : MonoBehaviour
{

    public int bullet = 0;
    public float speed = 20.0f;
    public float vertSpeed = 1.0f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        if (bullet > 0 & bullet < 2)
        { transform.Translate(0, vertSpeed * Time.deltaTime, 0); }

        if (bullet > 1 & bullet < 3)
        { transform.Translate(0, -vertSpeed * Time.deltaTime, 0); }
    }


    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
