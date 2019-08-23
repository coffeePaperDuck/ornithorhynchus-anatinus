using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupStar : MonoBehaviour
{
    public float powerup = 1;

    public Material powerupWidePrefab;
    public Material powerup1Prefab;

    public Material powerupAutoPrefab;
    public Material powerup2Prefab;

    public Material powerupPulsePrefab;
    public Material powerup3Prefab;

    public Material powerupRocketPrefab;
    public Material powerup4Prefab;

    Renderer rend;


    public int rot = 0;
    public float timer = 0;
    public float speed = -5.0f;

    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<Renderer>();

        // At start, use the first material
        rend.material = powerupWidePrefab;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        transform.eulerAngles = new Vector3(0, rot, 0);

        if (powerup > 0 && powerup < 2)
        {

        }

        //Star transitioning
        if (powerup > 1 && powerup < 2)
        {
            rend.material = powerup1Prefab;

            timer += 10.0f * Time.deltaTime;
            if (timer > 0.0f)
            {
                rot = -45;
                speed = 0;
                powerup += 2.0f * Time.deltaTime;
                transform.position += new Vector3(3 * Time.deltaTime, 0, 0);
            }
            if (timer > 1.0f)
            {
                rot = -90;
            }
            if (timer > 2.0f)
            {
                rot = -135;
            }
            if (timer > 3.0f)
            {
                rot = -180;
            }
            if (timer > 4.0)
            {
                rot = 0;
                speed = -5;
                rend.material = powerupAutoPrefab;
                timer = 0;
                powerup = 2;
            }
        }

        if (powerup > 2 && powerup < 3)
        {
            rend.material = powerup2Prefab;

            timer += 10.0f * Time.deltaTime;
            if (timer > 0.0f)
            {
                rot = -45;
                speed = 0;
                powerup += 2.0f * Time.deltaTime;
                transform.position += new Vector3(3 * Time.deltaTime, 0, 0);
            }
            if (timer > 1.0f)
            {
                rot = -90;
            }
            if (timer > 2.0f)
            {
                rot = -135;
            }
            if (timer > 3.0f)
            {
                rot = -180;
            }
            if (timer > 4.0)
            {
                rot = 0;
                speed = -5;
                rend.material = powerupPulsePrefab;
                timer = 0;
                powerup = 3;
            }
        }

        if (powerup > 3 && powerup < 4)
        {
            rend.material = powerup3Prefab;

            timer += 10.0f * Time.deltaTime;
            if (timer > 0.0f)
            {
                rot = -45;
                speed = 0;
                powerup += 2.0f * Time.deltaTime;
                transform.position += new Vector3(3 * Time.deltaTime, 0, 0);
            }
            if (timer > 1.0f)
            {
                rot = -90;
            }
            if (timer > 2.0f)
            {
                rot = -135;
            }
            if (timer > 3.0f)
            {
                rot = -180;
            }
            if (timer > 4.0)
            {
                rot = 0;
                speed = -5;
                rend.material = powerupRocketPrefab;
                timer = 0;
                powerup = 4;
            }
        }

        if (powerup > 4)
        {
            rend.material = powerup4Prefab;

            timer += 10.0f * Time.deltaTime;
            if (timer > 0.0f)
            {
                rot = -45;
                speed = 0;
                powerup += 2.0f * Time.deltaTime;
                transform.position += new Vector3(3 * Time.deltaTime, 0, 0);
            }
            if (timer > 1.0f)
            {
                rot = -90;
            }
            if (timer > 2.0f)
            {
                rot = -135;
            }
            if (timer > 3.0f)
            {
                rot = -180;
            }
            if (timer > 4.0)
            {
                rot = 0;
                speed = -5;
                rend.material = powerupWidePrefab;
                timer = 0;
                powerup = 1;
            }
        }

        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;
    }
}
