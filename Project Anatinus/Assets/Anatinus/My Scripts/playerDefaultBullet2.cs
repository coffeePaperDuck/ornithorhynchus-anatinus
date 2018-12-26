using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerDefaultBullet2 : MonoBehaviour
{
    public float speed = 20.0f;
    public float vertSpeed = -1.0f;
    public float timer = 1.0f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, vertSpeed * Time.deltaTime, 0);
        transform.eulerAngles = new Vector3(0, 0, 0);

        timer -= 5.0f * Time.deltaTime;
        if (timer < 0)
        {
            transform.Translate(0, -vertSpeed * Time.deltaTime, 0);
        }

        if (transform.position.x > 10)
        {
            //Destroy(GameObject.Find("bullet2(Clone)"));
        }
    }


    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
