using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debris : MonoBehaviour
{
    public GameObject graphics;

    public float animationTimer = 0;
    public float animationTimerSpeed = 20;
    public float spin = 0;
    public float spinAmount;
    public float forwardSpeed;
    public float ySpeed;
    public float yForce = 50;

    int direction;
    public int spinDirection;
    float rotation;

    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(0, 15);
        spinDirection = Random.Range(0, 10);

        ySpeed = Random.Range(5, 10);
        forwardSpeed = Random.Range(10, 20);

        if (direction == 1)
        { rotation = 22.5f; }

        if (direction == 2)
        { rotation = 45f; }

        if (direction == 3)
        { rotation = 67.5f; }

        if (direction == 4)
        { rotation = 90f; }

        if (direction == 5)
        { rotation = 112.5f; }

        if (direction == 6)
        { rotation = 135f; }

        if (direction == 7)
        { rotation = 157.5f; }

        if (direction == 8)
        { rotation = 180f; }

        if (direction == 9)
        { rotation = -22.5f; }

        if (direction == 10)
        { rotation = -45f; }

        if (direction == 11)
        { rotation = -67.5f; }

        if (direction == 12)
        { rotation = -90f; }

        if (direction == 13)
        { rotation = -112.5f; }

        if (direction == 14)
        { rotation = -135f; }

        if (direction == 15)
        { rotation = -157.5f; }

        if (spinDirection < 5)
        { spinAmount = -22.5f; }
        if (spinDirection > 5)
        { spinAmount = 22.5f; }

        transform.eulerAngles = new Vector3(rotation, rotation, rotation);
    }
    
    // Update is called once per frame
    void Update()
    {

        //Applies outward force to the object
        transform.Translate(0, 0, -forwardSpeed * Time.deltaTime);

        //Applies gravity to the object
        transform.Translate(0, ySpeed * Time.deltaTime, 0, 0);
        ySpeed -= yForce * Time.deltaTime;

        //Animation
        animationTimer += animationTimerSpeed * Time.deltaTime;
        if (animationTimer > 1)
        {
            spin += spinAmount;
            animationTimer = 0;
        }


        //Apply rotation
        graphics.transform.eulerAngles = new Vector3(0, spin, spin);
    }
}
