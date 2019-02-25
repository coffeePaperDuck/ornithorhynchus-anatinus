using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySquidMovement : MonoBehaviour
{
    public int maxSpeed = 9;

    public float xSpeed = 0;
    public float ySpeed = 0;

    public float fleeTimer = 15.0f;
    public bool fleeing = false;

    public float posX = 0;
    public float posY = 0;

    public float limitX = 0;
    public float limitX2 = 0;

    public float limitY = 0;
    public float limitY2 = 0;

    public float maxLimitTimer = 0.001f;
    public float limitTimer = 0.0f;

    // Use this for initialization
    void Start ()
    {
        if (transform.position.x < this.posX)
        {
            xSpeed = 9.0f;
        }
        if (transform.position.x > this.posX)
        {
            xSpeed = -9.0f;
        }
        if (transform.position.y < this.posX)
        {
            ySpeed = 9.0f;
        }
        if (transform.position.y > this.posX)
        {
            ySpeed = -9.0f;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        fleeTimer -= 1.0f * Time.deltaTime;
        limitTimer += 1.0f * Time.deltaTime;

        transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);

        //Make it so that these changes are based on time, rather than frames
        if (limitTimer > maxLimitTimer)
        {
            //Limit how far the enemy can sling.
            this.limitX = Random.Range(-90, 90);
            this.limitX2 = Random.Range(-90, 90);

            this.limitY = Random.Range(-90, 90);
            this.limitY2 = Random.Range(-90, 90);
            limitTimer = 0.0f;

            //Once the enemy has passed the marked position, change speed.
            if (this.transform.position.x < this.posX & this.xSpeed < maxSpeed & this.xSpeed < this.limitX)
            {
                xSpeed += 0.9f;
            }
            if (this.transform.position.x > this.posX & this.xSpeed > -maxSpeed & this.xSpeed > -this.limitX2)
            {
                xSpeed -= 0.9f;
            }
            if (this.transform.position.y < this.posY & this.ySpeed < maxSpeed & this.ySpeed < this.limitY)
            {
                ySpeed += 0.9f;
            }
            if (this.transform.position.y > this.posY & this.ySpeed > -maxSpeed & this.ySpeed > -this.limitY2)
            {
                ySpeed -= 0.9f;
            }

            //lock rotation
            transform.eulerAngles = new Vector3(0, 0, 0);

            //lock onto axises listed below
            Vector3 pos = transform.position;
            /*Z axis*/
            pos.z = 0;
            transform.position = pos;
        }

        //When fleeTimer runs out, fleeing = true.
        if (fleeTimer < 0.0f)
        {
            fleeing = true;
        }

        //If fleeing = true, mark an off-screen position for the enemy to fly to.
        if (fleeing != false)
        {
            posX = -100;
            if (this.transform.position.x < -20)
            { Destroy(gameObject); }
        }
    }
}
