//loganed by birth
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHulahoopAnimation : MonoBehaviour
{
    float _spin = 0.0f;
    public float spinTimer = 0;
    float spinSpeed = 24.0f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per tilt
    void Update()
    {
        var tf = transform;
        
        //spins
        spinTimer += spinSpeed * Time.deltaTime;
        if (spinTimer > 1.0f)
        {
            _spin += 22.5f;
            spinTimer = 0.0f;
        }

        //apply spins
        tf.eulerAngles = new Vector3(0, -_spin, 0);
        
        //Lock axes listed below (Z axis is typically locked to keep the object on the 2D plane)
        Vector3 axis = tf.position;
        /*Z Axis*/ axis.z = 0;
        tf.position = axis;

        //float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * tiltSpeed;
        //float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * tiltSpeed;
        //transform.Translate(0, 0, z);
    }
}