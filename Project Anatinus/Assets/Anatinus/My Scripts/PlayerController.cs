using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float speed = 10.0f;
    Rigidbody rb;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody> ();
	}

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        // Move player
        /*
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3 (horizontal*Time.deltaTime*speed, vertical*Time.deltaTime*speed, 0);
        rb.MovePosition(transform.position + movement);
        */
        float horz = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float vert = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        transform.Translate(horz, vert, 0);

        // Execute the [Command] to fire a bullet
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            CmdFire();
        }

        // Detect if bullet exists, then delete the bullet after going off the screen
        if (GameObject.Find("Bullet(Clone)") != null)
        {
            if (GameObject.Find("Bullet(Clone)").transform.position.x > 10)
            {
                Destroy(GameObject.Find("Bullet(Clone)"));
            }

        }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Command to fire bullets
    [Command]
    void CmdFire()
    {
        // Create bullet form the prefab
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 20.0f;

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet);

    }

}
