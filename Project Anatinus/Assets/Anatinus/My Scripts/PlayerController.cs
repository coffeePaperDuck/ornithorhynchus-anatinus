//birthed by logan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public GameObject defaultBullet1Prefab;
    public GameObject defaultBullet2Prefab;

    public GameObject wideBullet0Prefab;
    public GameObject wideBullet1Prefab;
    public GameObject wideBullet2Prefab;
    public GameObject wideBullet3Prefab;

    public GameObject sonicPrefab;
    public GameObject rocketPrefab;
    public GameObject lightningPrefab;

    public Transform bulletSpawn;
    public Transform rocketSpawn;

    public int powerUp = 0;
    public float animationTimer = 2.5f;
    public float speed = 10.0f;
    int tilt = 0;


    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Use this for initialization
    void Start ()
    {

	}

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            powerUp = 0;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            powerUp = 1;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            powerUp = 2;
        }

        //ship animation tilts
        if (animationTimer > 0.0f & animationTimer < 1.0f)
        { tilt = -30; }

        if (animationTimer > 1.0f & animationTimer < 2.0f)
        { tilt = -15; }

        if (animationTimer > 2.0f & animationTimer < 3.0f)
        { tilt = 0; }

        if (animationTimer > 3.0f & animationTimer < 4.0f)
        { tilt = 15; }

        if (animationTimer > 4.0f & animationTimer < 5.0f)
        { tilt = 30; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Move up
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);

            //tilt the ship up when the up key is pressed
            if (animationTimer < 5.0f)
            { animationTimer += 10.0f * Time.deltaTime; }
        }
        
        //tilt the ship back down when up key is released
        if (!Input.GetKey(KeyCode.UpArrow) & !Input.GetKey(KeyCode.DownArrow) & animationTimer > 3.0f)
        {
            animationTimer -= 10.0f * Time.deltaTime;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Move down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);

            //tilt the ship down when the down key is pressed
            if (animationTimer > 0)
            {animationTimer -= 10.0f * Time.deltaTime;}
        }

        //tilt the ship back up when the down key is released
        if (!Input.GetKey(KeyCode.DownArrow) & !Input.GetKey(KeyCode.UpArrow) & animationTimer < 2.0f)
        {
            animationTimer += 10.0f * Time.deltaTime;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        //apply tilts
        transform.eulerAngles = new Vector3(tilt, 0, 0);
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Execute the [Command] to fire a bullet
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            CmdFire();
        }

        // Detect if bullet exists, then delete the bullet after going off the screen
        if (GameObject.Find("bullet0(Clone)") != null)
        {
            if (GameObject.Find("bullet0(Clone)").transform.position.x > 10)
            {
                Destroy(GameObject.Find("bullet0(Clone)"));
            }
        }

        if (GameObject.Find("bullet1(Clone)") != null)
        {
            if (GameObject.Find("bullet1(Clone)").transform.position.x > 10)
            {
                Destroy(GameObject.Find("bullet1(Clone)"));
            }
        }

        if (GameObject.Find("bullet2(Clone)") != null)
        {
            if (GameObject.Find("bullet2(Clone)").transform.position.x > 10)
            {
                Destroy(GameObject.Find("bullet2(Clone)"));
            }
        }

        if (GameObject.Find("bullet3(Clone)") != null)
        {
            if (GameObject.Find("bullet3(Clone)").transform.position.x > 10)
            {
                Destroy(GameObject.Find("bullet3(Clone)"));
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Command to fire bullets
    [Command]
    void CmdFire()
    {
        // Create bullet from the prefab
        if (powerUp > -1 & powerUp < 1)
        {
            GameObject bullet1 = (GameObject)Instantiate(defaultBullet1Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject bullet2 = (GameObject)Instantiate(defaultBullet2Prefab, bulletSpawn.position, bulletSpawn.rotation);
            defaultBullet1Prefab.name = "bullet1";
            defaultBullet2Prefab.name = "bullet2";
            // Spawn the bullet on the Clients
            NetworkServer.Spawn(bullet1);
            NetworkServer.Spawn(bullet2);
        }

        if (powerUp > 0 & powerUp < 2)
        {
            GameObject bullet0 = (GameObject)Instantiate(wideBullet0Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject bullet1 = (GameObject)Instantiate(wideBullet1Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject bullet2 = (GameObject)Instantiate(wideBullet2Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject bullet3 = (GameObject)Instantiate(wideBullet3Prefab, bulletSpawn.position, bulletSpawn.rotation);
            wideBullet0Prefab.name = "bullet0";
            wideBullet1Prefab.name = "bullet1";
            wideBullet2Prefab.name = "bullet2";
            wideBullet3Prefab.name = "bullet3";
            // Spawn the bullet on the Clients
            NetworkServer.Spawn(bullet0);
            NetworkServer.Spawn(bullet1);
            NetworkServer.Spawn(bullet2);
            NetworkServer.Spawn(bullet3);
        }

    }

}
