using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float timer;
    public float timeSpeed = 1;
    public float timerMax = 1;

    // Update is called once per frame
    void Update()
    {
        var tf = transform;
        
        timer += timeSpeed * Time.deltaTime;
        if (timer > timerMax)
        {
            Instantiate(projectile, tf.position, tf.rotation);
            timer = 0;
        }
    }

}
