using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float timer;
    public float timerSpeed = 1;
    public float timerMax = 1;

    // Update is called once per frame
    void Update()
    {
        timer += timerSpeed * Time.deltaTime;
        if (timer > timerMax)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            timer = 0;
        }
    }

}
