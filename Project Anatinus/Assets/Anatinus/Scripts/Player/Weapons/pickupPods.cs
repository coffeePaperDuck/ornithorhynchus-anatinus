using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPods : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    // Start is called before the first frame update
    void Start()
    {
        xSpeed = -1;
        ySpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
        ySpeed -= 5 * Time.deltaTime;
    }
}
