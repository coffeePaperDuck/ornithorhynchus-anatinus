using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debris : MonoBehaviour
{
    public GameObject graphics;

    public float animationTimer = 0;
    public float animationTimerSpeed = 10;
    public float spin = 0;
    public float spinAmount = 22.5f;
    public float forwardSpeed = 10;
    public float ySpeed = 10;
    public float yForce = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animationTimer += animationTimerSpeed * Time.deltaTime;

        transform.Translate(0, 0, forwardSpeed * Time.deltaTime);

        transform.Translate(0, ySpeed * Time.deltaTime, 0, 0);
        ySpeed -= yForce * Time.deltaTime;

        if (animationTimer > 1)
        {
            spin += spinAmount;
            animationTimer = 0;
        }


        //apply rotation
        graphics.transform.eulerAngles = new Vector3(0, spin, spin);
    }
}
