using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloon : MonoBehaviour
{
    public GameObject balloonPrefab;
    public GameObject packagePrefab;

    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        balloonPrefab.name = "balloonPrefab";
        packagePrefab.name = "packagePrefab";

        //If balloon is missing, then fall like a lead mountain
        if (!GameObject.Find("balloonPrefab"))
        {
            speed -= 50 * Time.deltaTime;
        }

        //If package is missing, then rise like a balloon...go figure
        if (!GameObject.Find("packagePrefab"))
        {
            speed += 5 * Time.deltaTime;
        }

        //If both still exist, keep rising.
        if (GameObject.Find("balloonPrefab") & GameObject.Find("packagePrefab"))
        {
            speed += 1 * Time.deltaTime;
        }
    }
}
