//loganed by birth
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySaucer : MonoBehaviour
{
    public bool execute = false;

    public float animTime = 12;
    public float maxSpeed = 10;
    float _speed;
    public float xSpeed = -7;
    public int tilt = 0;

    void OnCollisionEnter(Collision collision)
    {
        execute = true;
    }

    // Update is called once per tilt
    void Update()
    {Transform tf;
        if (execute == true)
        {
            //Count timers
            animTime += 10 * Time.deltaTime;

            //tilts
            if (animTime > 1)
            {
                tilt = 15;
                _speed = maxSpeed / 2;
            }

            if (animTime > 2)
            {
                tilt = 30;
                _speed = maxSpeed;
            }

            if (animTime > 5)
            {
                tilt = 15;
                _speed = maxSpeed / 2;
            }

            if (animTime > 6)
            {
                tilt = 0;
                _speed = 0;
            }

            if (animTime > 7)
            {
                tilt = -15;
                _speed = -maxSpeed / 2;
            }

            if (animTime > 8)
            {
                tilt = -30;
                _speed = -maxSpeed;
            }

            if (animTime > 11)
            {
                tilt = -15;
                _speed = -maxSpeed / 2;
            }

            if (animTime > 12)
            {
                tilt = 0;
                _speed = 0;
                animTime = 0;
            }


            //apply tilts
            (tf = transform).Translate(xSpeed * Time.deltaTime, _speed * Time.deltaTime, 0);
            tf.eulerAngles = new Vector3(tilt, 0, 0);

            //Lock axes listed below (Z axis is typically locked to keep the object on the 2D plane)
            Vector3 axis = tf.position;
            /*Z axis*/
            axis.z = 0;
            tf.position = axis;
        }
    }
}