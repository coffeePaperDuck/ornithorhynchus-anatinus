using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerWideBullet0 : MonoBehaviour
{
    public float speed = 20.0f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        transform.eulerAngles = new Vector3(0, 0, 30);

        if (transform.position.x > 10)
        {
            //Destroy(GameObject.Find("bullet1(Clone)"));
        }
    }


    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
