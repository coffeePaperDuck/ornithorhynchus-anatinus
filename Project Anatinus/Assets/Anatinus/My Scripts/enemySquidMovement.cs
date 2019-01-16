using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySquidMovement : MonoBehaviour
{
    public float xSpeed = 0;
    public float ySpeed = 0;

    public float timer = 1.0f;
    public float fleeTimer = 15.0f;

    public bool fleeing = false;

    public float posY = 0;
    public float posX = 0;

    public float limitY = 0;
    public float limitY2 = 0;

    public float limitX = 0;
    public float limitX2 = 0;


    // Use this for initialization
    void Start ()
    {
        posX = 7.5f;
        posY = Random.Range(1.0f, 4.0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer -= 1.0f * Time.deltaTime;
        fleeTimer -= 1.0f * Time.deltaTime;

        transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);

        if (fleeing = false & timer < 0.0f)
        {
            limitX = Random.Range(0, 10);
            limitX2 = Random.Range(0, 10);

            limitY = Random.Range(0, 10);
            limitY2 = Random.Range(0, 10);

            timer = 1.0f;
        }

        if (fleeTimer < 0.0f)
        {
            fleeing = true;
        }

        //float x = transform.position.x;
        //float y = transform.position.y;
        if (transform.position.x < posX)
        {
            xSpeed += 0.5f;
        }
        if (transform.position.x > posX)
        {
            xSpeed -= 0.5f;
        }
        if (transform.position.y < posY)
        {
            ySpeed += 0.5f;
        }
        if (transform.position.x > posY)
        {
            ySpeed -= 0.5f;
        }
    }
}
