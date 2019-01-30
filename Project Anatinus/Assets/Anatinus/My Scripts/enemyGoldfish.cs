using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGoldfish : MonoBehaviour
{
    public int maxSpeed = 10;

    public float xSpeed = 0;

    public float fleeTimer = 15.0f;

    public bool fleeing = false;

    public float posX = 0;

    public float limitX = 0;
    public float limitX2 = 0;

    // Use this for initialization
    void Start ()
    {
        if (transform.position.x < this.posX)
        {
            xSpeed = 10.0f;
        }
        if (transform.position.x > this.posX)
        {
            xSpeed = -10.0f;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(xSpeed * Time.deltaTime, 0, 0);

        //Once the enemy has passed the marked position, change speed.
        if (this.transform.position.x < this.posX & this.xSpeed < maxSpeed & this.xSpeed < this.limitX)
        {
            xSpeed += 0.1f;
        }
        if (this.transform.position.x > this.posX & this.xSpeed > -maxSpeed & this.xSpeed > -this.limitX2)
        {
            xSpeed -= 0.1f;
        }
    }
}
