using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishmover2 : MonoBehaviour
{
    public float timer = 0.0f;
    public float speed;
    int tilt = 0;
    int rot = 0;
    public float pozition;


    // Use this for initialization
    void Start()
    {






    }









    // Update is called once per frame
    void Update()
    {


        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;





        transform.Translate(-speed, 0, 0);
        transform.eulerAngles = new Vector3(0, -rot, tilt);


        timer += 1.0f * Time.deltaTime;
        if (timer > 3.0f)
        {
            tilt = 5;
            rot = 5;
        }


        if (timer > 3.5f)
        {
            tilt = 10;
            rot = 10;
        }

        if (timer > 4)
        {
            tilt = 15;
            rot = 15;
        }

        if (timer > 4.5f)
        {
            tilt = 20;
            rot = 20;
        }

        if (timer > 4.7f)
        {
            tilt = 25;
            rot = 25;
        }

        if (timer > 5f)
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
        }

    }






}
