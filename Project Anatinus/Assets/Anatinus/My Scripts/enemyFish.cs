using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFish : MonoBehaviour
{

    public float timer = 0.0f;
    public float speed = 8.0f;
    int tilt = 0;
    int rot = 0;


    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Use this for initialization
    void Start()
    {
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Update is called once per frame
    void Update()
    {


        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;





        transform.Translate(-speed * Time.deltaTime, 0, 0);
        transform.eulerAngles = new Vector3(0, -rot, -tilt);
       

        timer += 2.5f * Time.deltaTime;
        if (timer > 6.0f)
        {
            tilt = 18;
            rot = 18;
            speed = 9.0f;
        }

       
        if (timer > 7.0f)
        {
            tilt = 36;
            rot = 36;
            speed = 10.0f;
        }

        if (timer > 8.0f)
        {
            tilt = 54;
            rot = 54;
            speed = 11.0f;
        }

        if (timer > 9.0f)
        {
            tilt = 72;
            rot = 72;
            speed = 12.0f;
        }

 /*       if (timer > 9.0f)
        {
            tilt = 90;
            rot = 90;
            speed = 10.0f;
        }

        if (timer > 6.0f)
        {
            tilt = 30;
            rot = 30;
        }

        if (timer > 5.3f)
        {
            tilt = 35;
            rot = 35;
        }

        if (timer > 5.6f)
        {
            tilt = 40;
            rot = 40;
        }

        if (timer > 5.9f)
        {
            tilt = 45;
            rot = 45;
        }

        if (timer > 6.1f)
        {
            tilt = 50;
            rot = 50;
        }

        if (timer > 6.3f)
        {
            tilt = 55;
            rot = 55;
        }

        if (timer > 6.5f)
        {
            tilt = 65;
            rot = 65;
        }

        if (timer > 6.7)
        {
            tilt = 65;
            rot = 65;
        }

        if (timer > 6.9f)
        {
            tilt = 70;
            rot = 70;
        }

        if (timer > 7.1f)
        {
            tilt = 75;
            rot = 75;
        }

        if (timer > 7.3f)
        {
            tilt = 80;
            rot = 80;
        }

        if (timer > 7.5f)
        {
            tilt = 85;
            rot = 85;
        }

        if (timer > 7.7f)
        {
            tilt = 90;
            rot = 90;
        }*/

    }






}
