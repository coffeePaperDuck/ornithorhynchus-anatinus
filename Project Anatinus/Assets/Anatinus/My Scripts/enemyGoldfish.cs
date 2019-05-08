using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGoldfish : MonoBehaviour
{
    public int maxSpeed;

    public float xSpeed;

    public float posX;

    public float limitX;
    public float limitX2;

    // Use this for initialization
    void Start ()
    {
        /*if (transform.position.x < this.posX)
        {
            xSpeed = 10.0f;
        }
        if (transform.position.x > this.posX)
        {
            xSpeed = -10.0f;
        }*/
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(xSpeed * Time.deltaTime, 0, 0);

        //Once the enemy has passed the marked position, change speed.
        if (this.transform.position.x < this.posX & this.xSpeed < maxSpeed & this.xSpeed < this.limitX)
        {
            xSpeed += 7 * Time.deltaTime;
        }
        if (this.transform.position.x > this.posX & this.xSpeed > -maxSpeed & this.xSpeed > -this.limitX2)
        {
            xSpeed -= 7 * Time.deltaTime;
        }
    }
}
