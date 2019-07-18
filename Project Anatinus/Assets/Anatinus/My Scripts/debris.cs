using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debris : MonoBehaviour
{
    public GameObject graphics;

    public float animationTimer = 0;
    public float animationTimerSpeed = 10;
    public float spin = 0;
    public float ySpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animationTimer += animationTimerSpeed * Time.deltaTime;

        transform.Translate(0, ySpeed * Time.deltaTime, 0);
        ySpeed -= 10 * Time.deltaTime;

        if (animationTimer > 1)
        {
            spin += 22.5f;
            animationTimer = 0;
        }


        //apply rotation
        graphics.transform.eulerAngles = new Vector3(0, spin, spin);
    }
}
