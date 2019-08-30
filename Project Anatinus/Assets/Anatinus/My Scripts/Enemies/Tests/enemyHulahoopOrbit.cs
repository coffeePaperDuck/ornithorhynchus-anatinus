//loganed by birth
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHulahoopOrbit : MonoBehaviour
{
    public float animationTimer = 12;
    public float maxSpeed = 10;
    float _speed;
    public int tilt = 0;

    // Update is called once per tilt
    void Update()
    {
        //transform
        var tf = transform;
        
        //Count timers
        animationTimer += 10 * Time.deltaTime;

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
        tf.eulerAngles = new Vector3(tilt, 0, 0);
        Vector3 pos = tf.position;
        pos.z = 0;
        tf.position = pos;

        //float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        //float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        //transform.Translate(0, 0, z);
    }
}