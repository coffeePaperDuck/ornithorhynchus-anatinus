using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class enemyHammerhead : MonoBehaviour
{
    public bool execute = false;

    public int maxSpeed;
    public float xSpeed;
    public float posX;
    public float posX2;

    public float limitX;
    public float limitX2;

    public Transform missileLauncher1;
    public Transform missileLauncher2;
    public GameObject missile;

    public float timer;
    public float timerSpeed = 1;
    public float timerMax = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        execute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (execute == true)
        {
            transform.Translate(xSpeed * Time.deltaTime, 0, 0);

            //Once the enemy has passed the marked position, change speed.
            if (this.transform.position.x < this.posX && this.transform.position.x > this.posX2 && this.xSpeed < maxSpeed && this.xSpeed < this.limitX)
            {
                xSpeed += 5 * Time.deltaTime;
            }
            if (this.transform.position.x < this.posX2 && this.xSpeed < maxSpeed && this.xSpeed < this.limitX)
            {
                xSpeed += 1 * Time.deltaTime;
            }

            if (this.transform.position.x > this.posX && this.xSpeed > -maxSpeed && this.xSpeed > -this.limitX2)
            {
                xSpeed -= 5 * Time.deltaTime;
            }


            timer += timerSpeed * Time.deltaTime;
            if (timer > timerMax)
            {
                LeanPool.Spawn(missile, missileLauncher1.position, missileLauncher1.rotation);
                LeanPool.Spawn(missile, missileLauncher2.position, missileLauncher2.rotation);
                timer = 0;
            }
        }
    }
}
