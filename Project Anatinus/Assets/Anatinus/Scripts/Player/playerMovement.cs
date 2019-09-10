using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float _xSpeed; //horizontal speed
    [SerializeField] private float _ySpeed; //vertical speed

    [SerializeField] private float _xClamp; //left and right screen barriers
    [SerializeField] private float _yClamp; //top and bottom screen barriers

    Rigidbody rb;

    public bool allowMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (allowMovement)
        {
            var pos = transform.position;

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // Movement input

            Vector2 input = new Vector2
            (
            Input.GetAxisRaw("Horizontal") * _xSpeed, //apply speed to any left and right inputs
            Input.GetAxisRaw("Vertical") * _ySpeed //apply speed to any up and down inputs
            );

            rb.velocity = input;

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // Prevent player from going off-screen

            //right side
            if (pos.x > _xClamp) //if player touches right side...
            { pos.x = _xClamp; } //...don't let player go past right side

            //left side
            if (pos.x < -_xClamp) //if player touches left side...
            { pos.x = -_xClamp; } //...don't let player go past left side

            //top side
            if (pos.y > _yClamp) //if player touches top side...
            { pos.y = _yClamp; } //...don't let player go past top side

            //bottom side
            if (pos.y < -_yClamp) //if player touches bottom side...
            { pos.y = -_yClamp; } //...don't let player go past bottom side

            transform.position = pos; //apply position to pos variable

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //Lock axes listed below (Z axis is typically locked to keep the object on the 2D plane)
            Vector3 axis = transform.position;
            axis.z = 0; //Lock Z axis
            transform.position = axis; //keep player position on axes listed above
        }
    }
}
