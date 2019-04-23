using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPods : MonoBehaviour
{
    public float vertSpeed;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = -1;
        vertSpeed = 5;
}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, vertSpeed * Time.deltaTime, 0);
        vertSpeed -= 5 * Time.deltaTime;
    }
}
