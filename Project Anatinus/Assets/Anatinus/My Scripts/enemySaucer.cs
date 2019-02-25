//loganed by birth
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class enemySaucer : NetworkBehaviour
{
    [SyncVar]
    public float animationTimer = 12.0f;
    [SyncVar]
    public float maxSpeed = 10.0f;
    [SyncVar]
    float speed;
    [SyncVar]
    int tilt = 0;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per tilt
    void Update()
    {
        //Count up timer
        animationTimer += 10.0f * Time.deltaTime;

        //tilts
        if (animationTimer > 1.0f)
        {
            tilt = 15;
            speed = maxSpeed / 2;
        }

        if (animationTimer > 2.0f)
        {
            tilt = 30;
            speed = maxSpeed;
        }

        if (animationTimer > 5.0f)
        {
            tilt = 15;
            speed = maxSpeed / 2;
        }

        if (animationTimer > 6.0f)
        {
            tilt = 0;
            speed = 0.0f;
        }

        if (animationTimer > 7.0f)
        {
            tilt = -15;
            speed = -maxSpeed / 2;
        }

        if (animationTimer > 8.0f)
        {
            tilt = -30;
            speed = -maxSpeed;
        }

        if (animationTimer > 11.0f)
        {
            tilt = -15;
            speed = -maxSpeed / 2;
        }

        if (animationTimer > 12.0f)
        {
            tilt = 0;
            speed = 0.0f;
            animationTimer = 0.0f;
        }


        //apply tilts
        transform.Translate(0, speed * Time.deltaTime, 0);
        transform.eulerAngles = new Vector3(tilt, 0, 0);
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;

        //float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        //float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        //transform.Translate(0, 0, z);
    }
}