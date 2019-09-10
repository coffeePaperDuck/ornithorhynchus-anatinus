using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFish : MonoBehaviour
{
    public float timer = 0.0f;
    public float speed = 8.0f;
    public float speedIncrease = 1.0f;
    public int direction;
    //0 = down
    //1 = up
    //2 = < formation //not yet implemented
    //3 = > formation //not yet implemented
    //4 = ( formation //not yet implemented
    //5 = twirling //not yet implemented

    int _tilt = 0;
    int _rot = 0;


    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Update is called once per frame
    void Update()
    {
        //transform
        var tf = transform;
        
        //Lock axes listed below (Z axis is typically locked to keep the object on the 2D plane)
        Vector3 axis = tf.position;
        /*Z axis*/ axis.z = 0;
        tf.position = axis;

        //Apply speed/tilt/rot
        tf.Translate(-speed * Time.deltaTime, 0, 0);
        tf.eulerAngles = new Vector3(0, -_rot, _tilt);

        timer += 1.0f * Time.deltaTime;

        //Change direction
        if (tf.position.x < 2.4f && timer > 0.3f)
        {
            if (_rot != 54)
            {
                if (direction == 1)
                {
                    _tilt -= 18; //Tilt the other way
                }
                else { _tilt += 18; }
                _rot += 18;
                speed += speedIncrease;
                speedIncrease += speedIncrease;
            }
            timer = 0f;
        }
    
        /*
        if (timer > 1.0f)
        {
            tilt = 36;
            rot = 36;
            speed = 10.0f;
        }

        if (timer > 2.0f)
        {
            tilt = 54;
            rot = 54;
            speed = 11.0f;
        }

        if (timer > 3.0f)
        {
            tilt = 72;
            rot = 72;
            speed = 12.0f;
        }

        if (timer > 9.0f)
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
