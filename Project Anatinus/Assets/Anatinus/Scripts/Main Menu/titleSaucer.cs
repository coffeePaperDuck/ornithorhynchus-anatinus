//loganed by birth
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleSaucer : MonoBehaviour
{
    public float animationTimer = 12;
    public float animationTimerSpeed;
    public float maxSpeed = 10;
    float speed;

    // Update is called once per tilt
    void Update()
    {
        //Count timers
        animationTimer += animationTimerSpeed * Time.deltaTime;

        //tilts
        if (animationTimer > 1)
        {
            speed = maxSpeed / 2;
        }

        if (animationTimer > 2)
        {
            speed = maxSpeed;
        }

        if (animationTimer > 5)
        {
            speed = maxSpeed / 2;
        }

        if (animationTimer > 6)
        {
            speed = 0;
        }

        if (animationTimer > 7)
        {
            speed = -maxSpeed / 2;
        }

        if (animationTimer > 8)
        {
            speed = -maxSpeed;
        }

        if (animationTimer > 11)
        {
            speed = -maxSpeed / 2;
        }

        if (animationTimer > 12)
        {
            speed = 0;
            animationTimer = 0;
        }


        //apply tilts
        transform.Translate(0, speed * Time.deltaTime, 0);

        //float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        //float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        //transform.Translate(0, 0, z);
    }
}