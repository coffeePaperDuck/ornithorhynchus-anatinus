//loganed by birth
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySaucerHulahoop : MonoBehaviour
{
    public GameObject gunPrefab;
    public GameObject hulahoop;
    public GameObject hulahoopOrbit;

    public float animationTimer = 12;
    public float shootingTimer = 2;
    public float maxSpeed = 10;
    float speed;
    public float xSpeed = -7;
    public int tilt = 0;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per tilt
    void Update()
    {
        //hulahoop
        hulahoop.transform.position = hulahoopOrbit.transform.position;

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
            tilt = 15;
            speed = maxSpeed / 2;
        }

        if (animationTimer > 2)
        {
            tilt = 30;
            speed = maxSpeed;
        }

        if (animationTimer > 5)
        {
            tilt = 15;
            speed = maxSpeed / 2;
        }

        if (animationTimer > 6)
        {
            tilt = 0;
            speed = 0;
        }

        if (animationTimer > 7)
        {
            tilt = -15;
            speed = -maxSpeed / 2;
        }

        if (animationTimer > 8)
        {
            tilt = -30;
            speed = -maxSpeed;
        }

        if (animationTimer > 11)
        {
            tilt = -15;
            speed = -maxSpeed / 2;
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