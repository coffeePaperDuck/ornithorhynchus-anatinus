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

    int _direction;
    public int spinDirection;
    float _rotation;

    // Start is called before the first frame update
    void Start()
    {
        _direction = Random.Range(0, 15);
        spinDirection = Random.Range(0, 10);

        ySpeed = Random.Range(5, 10);
        forwardSpeed = Random.Range(10, 20);

        if (_direction == 1)
        { _rotation = 22.5f; }

        if (_direction == 2)
        { _rotation = 45f; }

        if (_direction == 3)
        { _rotation = 67.5f; }

        if (_direction == 4)
        { _rotation = 90f; }

        if (_direction == 5)
        { _rotation = 112.5f; }

        if (_direction == 6)
        { _rotation = 135f; }

        if (_direction == 7)
        { _rotation = 157.5f; }

        if (_direction == 8)
        { _rotation = 180f; }

        if (_direction == 9)
        { _rotation = -22.5f; }

        if (_direction == 10)
        { _rotation = -45f; }

        if (_direction == 11)
        { _rotation = -67.5f; }

        if (_direction == 12)
        { _rotation = -90f; }

        if (_direction == 13)
        { _rotation = -112.5f; }

        if (_direction == 14)
        { _rotation = -135f; }

        if (_direction == 15)
        { _rotation = -157.5f; }

        if (spinDirection < 5)
        { spinAmount = -22.5f; }
        if (spinDirection > 5)
        { spinAmount = 22.5f; }

        transform.eulerAngles = new Vector3(_rotation, _rotation, _rotation);
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
