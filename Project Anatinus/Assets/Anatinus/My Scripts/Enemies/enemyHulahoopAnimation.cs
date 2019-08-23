//loganed by birth
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHulahoopAnimation : MonoBehaviour
{
    float spin = 0.0f;
    public float spinTimer = 0;
    float spinSpeed = 24.0f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per tilt
    void Update()
    {
        //spins
        spinTimer += spinSpeed * Time.deltaTime;
        if (spinTimer > 1.0f)
        {
            spin += 22.5f;
            spinTimer = 0.0f;
        }

        //apply spins
        transform.eulerAngles = new Vector3(0, -spin, 0);
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;

        //float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * tiltSpeed;
        //float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * tiltSpeed;
        //transform.Translate(0, 0, z);
    }
}