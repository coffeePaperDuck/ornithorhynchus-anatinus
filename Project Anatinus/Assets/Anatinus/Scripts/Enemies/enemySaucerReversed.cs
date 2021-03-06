﻿//loganed by birth
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySaucerReversed : MonoBehaviour
{
    public GameObject gunPrefab;

    public float animationTimer = 12;
    public float shootingTimer = 2;
    public float maxSpeed = 10;
    float _speed;
    public float xSpeed = -10;
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
            _speed = -maxSpeed / 2;
        }

        if (animationTimer > 2)
        {
            tilt = -30;
            _speed = -maxSpeed;
        }

        if (animationTimer > 5)
        {
            tilt = -15;
            _speed = -maxSpeed / 2;
        }

        if (animationTimer > 6)
        {
            tilt = 0;
            _speed = 0;
        }

        if (animationTimer > 7)
        {
            tilt = 15;
            _speed = maxSpeed / 2;
        }

        if (animationTimer > 8)
        {
            tilt = 30;
            _speed = maxSpeed;
        }

        if (animationTimer > 11)
        {
            tilt = 15;
            _speed = maxSpeed / 2;
        }

        if (animationTimer > 12)
        {
            tilt = 0;
            _speed = 0;
            animationTimer = 0;
        }


        //apply tilts
        Transform transform1;
        
        (transform1 = transform).Translate(xSpeed * Time.deltaTime, _speed * Time.deltaTime, 0);
        transform1.eulerAngles = new Vector3(tilt, 0, 0);
        
        Vector3 pos = transform1.position;
        pos.z = 0;
        transform1.position = pos;

        //float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        //float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        //transform.Translate(0, 0, z);
    }
}