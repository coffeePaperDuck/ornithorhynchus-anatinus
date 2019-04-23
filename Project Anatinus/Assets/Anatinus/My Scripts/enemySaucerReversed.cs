//loganed by birth
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class enemySaucerReversed : NetworkBehaviour
{
    public GameObject gunPrefab;

    [SyncVar]
    public float animationTimer = 12;
    [SyncVar]
    public float shootingTimer = 2;
    [SyncVar]
    public float maxSpeed = 10;
    [SyncVar]
    float speed;
    [SyncVar]
    public float xSpeed = -10;
    [SyncVar]
    public int tilt = 0;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per tilt
    void Update()
    {
        //Count timers
        animationTimer += 10 * Time.deltaTime;
        shootingTimer -= 1 * Time.deltaTime;

        //shooting
        if (shootingTimer < 0)
        {
        }

        //tilts
        if (animationTimer > 1)
        {
            tilt = -15;
            speed = -maxSpeed / 2;
        }

        if (animationTimer > 2)
        {
            tilt = -30;
            speed = -maxSpeed;
        }

        if (animationTimer > 5)
        {
            tilt = -15;
            speed = -maxSpeed / 2;
        }

        if (animationTimer > 6)
        {
            tilt = 0;
            speed = 0;
        }

        if (animationTimer > 7)
        {
            tilt = 15;
            speed = maxSpeed / 2;
        }

        if (animationTimer > 8)
        {
            tilt = 30;
            speed = maxSpeed;
        }

        if (animationTimer > 11)
        {
            tilt = 15;
            speed = maxSpeed / 2;
        }

        if (animationTimer > 12)
        {
            tilt = 0;
            speed = 0;
            animationTimer = 0;
        }


        //apply tilts
        transform.Translate(xSpeed * Time.deltaTime, speed * Time.deltaTime, 0);
        transform.eulerAngles = new Vector3(tilt, 0, 0);
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;

        //float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        //float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        //transform.Translate(0, 0, z);
    }
}