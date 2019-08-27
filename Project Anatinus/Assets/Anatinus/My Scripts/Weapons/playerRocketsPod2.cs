using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerRocketsPod2 : MonoBehaviour
{
    public int lit = 0;
    public float xSpeed;
    public float ySpeed;
    public float zSpeed;
    public float timer = 0.0f;
    public float dmg;

    public Mesh rocket5Prefab;
    public Mesh rocket4Prefab;
    public Mesh rocket3Prefab;
    public Mesh rocket2Prefab;
    public Mesh rocket1Prefab;

    // Use this for initialization
    void Start()
    {
        ySpeed = -15;
        GetComponent<MeshFilter>().mesh = rocket5Prefab;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, 0);

        if (lit == 1)
        {
            timer += 2.0f * Time.deltaTime;
            GetComponent<MeshFilter>().mesh = rocket4Prefab;
            xSpeed = 10;
            ySpeed = -7.5f;
        }

        if (timer > 0.1)
        {
            GetComponent<MeshFilter>().mesh = rocket3Prefab;
            xSpeed = 20;
            ySpeed = 10f;
        }

        if (timer > 0.2)
        {
            GetComponent<MeshFilter>().mesh = rocket2Prefab;
            xSpeed = 10;
            ySpeed = 5f;
        }

        if (timer > 0.3)
        {
            GetComponent<MeshFilter>().mesh = rocket1Prefab;
            xSpeed = 20;
            ySpeed = 0;
        }

        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 7.5 || transform.position.y < -7.5)
        {
            //LeanPool.Despawn(gameObject);
        }

        if (transform.position.z > 0)
        {
            zSpeed = -1f;
        }
        if (transform.position.z < 0)
        {
            zSpeed = 1f;
        }
    }

    //Collisions
    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();
        powerupStar powerup = hit.GetComponent<powerupStar>();

        if (health != null)
        {
            health.TakeDamage(dmg);
            //LeanPool.Despawn(gameObject);
        }
        if (powerup != null)
        {
            if (powerup.timer < 0.3)
            {
                powerup.powerup += 0.01f;
                //LeanPool.Despawn(gameObject);
            }
        }
    }

    void OnDisable()
    {
        this.name = "rocketPod2";

        GetComponent<MeshFilter>().mesh = rocket5Prefab;
        lit = 0;
        timer = 0.0f;
        xSpeed = 0.0f;
        ySpeed = -15;
    }
}
