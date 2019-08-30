using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float _xSpeed;
    [SerializeField] private float _ySpeed;

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
        if (allowMovement) //if you're allowed to move...
        {
            Vector2 input = new Vector2
            (
            Input.GetAxisRaw("Horizontal") * _xSpeed, //...then apply speed to any left and right inputs...
            Input.GetAxisRaw("Vertical") * _ySpeed //...and apply speed to any up and down inputs
            );

            rb.velocity = input;
        }
    }
}
