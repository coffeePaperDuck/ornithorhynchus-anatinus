//birthed by logan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
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
        /*if (GameObject.Find("bullet1") != null)
        {
            GameObject.Find("bullet1").GetComponent<playerBullet>().bullet = 1;
            if (GameObject.Find("bullet1").transform.position.x > 10)
            {
                Destroy(GameObject.Find("bullet1"));
            }
        }
        if (GameObject.Find("bullet2") != null)
        {
            GameObject.Find("bullet2").GetComponent<playerBullet>().bullet = 2;
            if (GameObject.Find("bullet2").transform.position.x > 10)
            {
                Destroy(GameObject.Find("bullet2"));
            }
        }*/
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Command to fire bullets
    [Command]
    void CmdFire()
    {

        // Create bullet from the prefab
        GameObject bullet1 = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        GameObject bullet2 = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet1.name = "bullet1";
        bullet2.name = "bullet2";


        // Add velocity to the bullet


        // Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet1);
        NetworkServer.Spawn(bullet2);

    }

}
