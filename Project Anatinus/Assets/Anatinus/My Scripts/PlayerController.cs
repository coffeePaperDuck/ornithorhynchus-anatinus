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

    [SyncVar]
    public int autofireBulletCount;
    [SyncVar]
    public float autofireTimerMax = 1;
    [SyncVar]
    public float autofireTimer = 1;

    public GameObject sonicPrefab;
    [SyncVar]
    public int pulseCountMax = 3;
    [SyncVar]
    public int pulseCount;
    [SyncVar]
    public float pulseTimerMax = 0.5f;
    [SyncVar]
    public float pulseTimer;

    public GameObject rocketPrefab;
    private GameObject rocket;

    public GameObject lightningPrefab;

    public Transform bulletSpawn;
    public Transform rocketSpawn;

    [SyncVar]
    public int powerup = 0;
    [SyncVar]
    public int powerupTimer = 0;
    [SyncVar]
    public float animationTimer = 2.5f;
    [SyncVar]
    public float speed = 10.0f;
    [SyncVar]
    public float dmg;
    [SyncVar]
    int tilt = 0;


    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Use this for initialization
    void Start()
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
            powerup = 0;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            powerup = 1;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            powerup = 2;
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            powerup = 3;
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            powerup = 4;
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            powerup = 5;
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
            { animationTimer -= 10.0f * Time.deltaTime; }
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //apply tilts
        transform.eulerAngles = new Vector3(tilt, 0, 0);

        //lock onto axises listed below
        Vector3 pos = transform.position;
        /*Z axis*/
        pos.z = 0;
        transform.position = pos;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Execute the [Command] to fire a bullet
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            //Anything else
            if (powerup != 2 & powerup != 3)
            {
                CmdFire();
            }

            //Autofire
            if (powerup > 1 & powerup < 3)
            {
                if (autofireBulletCount < 5)
                {
                    autofireBulletCount += 5;
                }
            }

            //Sonic Pulse
            if (powerup > 2 & powerup < 4)
            {
                if (pulseCount != 0)
                {
                    pulseCount -= 1;
                    CmdFire();
                }
            }
        }

        //Keep Autofire refilled
        if (autofireTimer < autofireTimerMax * 2)
        {
            autofireTimer += 20.0f * Time.deltaTime;
        }
        if (autofireTimer > autofireTimerMax & autofireBulletCount != 0)
        {
            autofireTimer = 0;
            autofireBulletCount -= 1;
            CmdFire();
        }

        //Refill Sonic Pulse
        if (pulseTimer < pulseTimerMax & pulseCount != pulseCountMax)
        {
            pulseTimer += 1.0f * Time.deltaTime;
        }
        if (pulseTimer > pulseTimerMax & pulseCount != 3)
        {
            pulseTimer = 0;
            pulseCount += 1;
        }

        //Rocketman
        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            if (powerup > 3 & powerup < 5)
            {
                CmdLite();
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Command to fire bullets
    [Command]
    void CmdFire()
    {
        //Default
        if (powerup > -1 & powerup < 1)
        {
            // Create bullets from the prefabs
            GameObject bullet1 = (GameObject)Instantiate(defaultBullet1Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject bullet2 = (GameObject)Instantiate(defaultBullet2Prefab, bulletSpawn.position, bulletSpawn.rotation);
            defaultBullet1Prefab.name = "bullet1";
            defaultBullet2Prefab.name = "bullet2";
            // Spawn the bullet on the Clients
            NetworkServer.Spawn(bullet1);
            NetworkServer.Spawn(bullet2);
        }

        //Wideshot
        if (powerup > 0 & powerup < 2)
        {
            // Create bullets from the prefabs
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

        //Autofire
        if (powerup > 1 & powerup < 3)
        {
            // Create bullets from the prefabs
            GameObject bullet1 = (GameObject)Instantiate(defaultBullet1Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject bullet2 = (GameObject)Instantiate(defaultBullet2Prefab, bulletSpawn.position, bulletSpawn.rotation);
            defaultBullet1Prefab.name = "bullet1";
            defaultBullet2Prefab.name = "bullet2";
            // Spawn the bullet on the Clients
            NetworkServer.Spawn(bullet1);
            NetworkServer.Spawn(bullet2);
        }

        //Sonic Pulse
        if (powerup > 2 & powerup < 4)
        {
            // Create pulses from the prefabs
            GameObject pulse1 = (GameObject)Instantiate(sonicPrefab, bulletSpawn.position, bulletSpawn.rotation);
            sonicPrefab.name = "pulse1";
            // Spawn the pulse on the Clients
            NetworkServer.Spawn(pulse1);
        }

        //Rockets
        if (powerup > 3 & powerup < 5)
        {
            // Create rockets from the prefabs
            GameObject rocket1 = (GameObject)Instantiate(rocketPrefab, rocketSpawn.position, rocketSpawn.rotation);
            rocketPrefab.name = "rocket1";
            // Spawn the rocket on the Clients
            NetworkServer.Spawn(rocket1);
        }
    }

    //Rocket fuse
    [Command]
    void CmdLite()
    {
        rocket = GameObject.Find("rocket1(Clone)");
        if (rocket != null)
        {
            playerRockets rocket1 = rocket.GetComponent<playerRockets>();
            rocket1.lit = 1;
            rocket1.name = "rocket1Lit";
        }
    }

    //Collisions
    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();
        powerupStar powerupStar = hit.GetComponent<powerupStar>();

        if (health != null)
        {
            health.TakeDamage(dmg);
            Destroy(gameObject);
        }
        if (powerupStar != null)
        {
            if (powerupStar.powerup > 0 & powerupStar.powerup < 1.5)
            {
                powerup = 1;
            }

            if (powerupStar.powerup > 1.5 & powerupStar.powerup < 2.5)
            {
                powerup = 2;
            }

            if (powerupStar.powerup > 2.5 & powerupStar.powerup < 3.5)
            {
                powerup = 3;
            }

            if (powerupStar.powerup > 3.5 & powerupStar.powerup < 4.5)
            {
                powerup = 4;
            }

            if (powerupStar.powerup > 4.5 & powerupStar.powerup < 5.5)
            {
                powerup = 1;
            }
        }
    }

}
