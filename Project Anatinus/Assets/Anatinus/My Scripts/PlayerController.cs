//birthed by logan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Lean.Pool;

public class PlayerController : NetworkBehaviour
{
    [SyncVar]
    public int alive = 1;
    [SyncVar]
    public int lives = 4;
    [SyncVar]
    public float respawnTimer = 1.5f;


    [SyncVar]
    public int powerup = 0;
    [SyncVar]
    public int powerupTimer = 0;


    [SyncVar]
    public int weaponPods = 0;
    [SyncVar]
    public int pointsDoubler = 0;


    [SyncVar]
    public float dmg;
    [SyncVar]
    public float speed = 10.0f;
    [SyncVar]
    int tilt = 0;
    [SyncVar]
    public float animationTimer = 2.5f;


    public Transform bulletSpawn;
    public Transform rocketSpawn;
    public Transform centerOrbit;
    public Transform podOneSpawn;
    public Transform podTwoSpawn;


    public GameObject weaponPodsPrefab;
    public GameObject pointsDoublerPrefab;

    //FUCKADOOBITCH
    public GameObject defaultBullet1Prefab;
    public GameObject defaultBullet2Prefab;
    public GameObject defaultBulletPodPrefab;


    public GameObject wideBullet0Prefab;
    public GameObject wideBullet1Prefab;
    public GameObject wideBullet2Prefab;
    public GameObject wideBullet3Prefab;
    public GameObject wideBulletPodPrefab;


    public GameObject autoBullet1Prefab;
    public GameObject autoBullet2Prefab;
    public GameObject blueBulletLightPrefab;
    public GameObject autoBulletPodPrefab;


    public GameObject sonicPrefab;


    public GameObject rocketPrefab;
    public GameObject rocketPod1Prefab;
    public GameObject rocketPod2Prefab;
    private GameObject rocket;
    private GameObject rocketPod1;
    private GameObject rocketPod2;


    public GameObject lightningPrefab;


    [SyncVar]
    public int autofireBulletCount;
    [SyncVar]
    public float autofireTimerMax = 1;
    [SyncVar]
    public float autofireTimer = 1;
    [SyncVar]
    public int autofireLightCount;
    [SyncVar]
    public float autofireLightTimerMax = 1;
    [SyncVar]
    public float autofireLightTimer = 1;


    [SyncVar]
    public int pulseCountMax = 3;
    [SyncVar]
    public int pulseCount;
    [SyncVar]
    public float pulseTimerMax = 0.5f;
    [SyncVar]
    public float pulseTimer;


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

        //Execute the code below if alive
        if (alive > 0)
        {
                    //TESTINGvvv
                    if (isServer)
                    {
                        Debug.Log("I'm the server");
                    }
                    if (!isServer)
                    {
                        Debug.Log("I'm the client");
                    }
                    //TESTING^^^

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

            //boundaries
            //top 7.13
            //left -9.29
            //right 9.47
            //bottom -7.07

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // Move up
            if (Input.GetKey(KeyCode.UpArrow) & transform.position.y < 7.13)
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
            if (Input.GetKey(KeyCode.LeftArrow) & transform.position.x > -9.29)
            {
                    transform.Translate(-speed * Time.deltaTime, 0, 0);
            }


            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // Move down
            if (Input.GetKey(KeyCode.DownArrow) & transform.position.y > -7.07)
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
            if (Input.GetKey(KeyCode.RightArrow) & transform.position.x < 9.47)
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
                //Autofire
                if (powerup == 2)
                {
                    if (autofireBulletCount < 5)
                    {
                        autofireBulletCount += 5;
                    }
                    if (autofireLightCount < 3)
                    {
                        autofireLightCount += 3;
                    }
                }

                //Sonic Pulse
                if (powerup == 3)
                {
                    if (pulseCount != 0)
                    {
                        pulseCount -= 1;
                        CmdFire();
                    }
                }

                //Anything else
                if (powerup != 2 & powerup != 3)
                {
                    CmdFire();
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

            //Keep Autofire lit bro
            if (autofireLightTimer < autofireLightTimerMax * 2)
            {
                autofireLightTimer += 10.0f * Time.deltaTime;
            }
            if (autofireLightTimer > autofireLightTimerMax & autofireLightCount != 0)
            {
                autofireLightTimer = 0;
                autofireLightCount -= 1;
                CmdLite();
            }

            //Refill Sonic Pulse
            if (pulseCount != pulseCountMax)
            {
                pulseTimer += 1.0f * Time.deltaTime;
            }
            if (pulseTimer > pulseTimerMax & pulseCount != pulseCountMax)
            {
                pulseTimer = 0;
                pulseCount += 1;

            }

            //Rocketman
            if (Input.GetKeyUp(KeyCode.RightControl))
            {
                if (powerup == 4)
                {
                    CmdLite();
                }
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Weapon Pods
        if (weaponPods == 1)
        {
            weaponPodsPrefab.SetActive(true);
        }
        else
        {
            weaponPodsPrefab.SetActive(false);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Respawn Ship
        if (alive < 1 & lives > 0)
        {
            respawnTimer -= 1.0f * Time.deltaTime;
            if (respawnTimer < 0)
            {
                alive = 1;
                lives -= 1;

                powerup = 0;
                weaponPods = 0;
                pointsDoubler = 0;

                respawnTimer = 1.5f;
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Command to fire bullets
    [Command]
    void CmdFire()
    {
        //Default
        if (powerup == 0)
        {
            // Create bullets from the prefabs
            GameObject bullet1 = (GameObject)LeanPool.Spawn(defaultBullet1Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject bullet2 = (GameObject)LeanPool.Spawn(defaultBullet2Prefab, bulletSpawn.position, bulletSpawn.rotation);
            defaultBullet1Prefab.name = "bullet1";
            defaultBullet2Prefab.name = "bullet2";
            // Spawn the bullet on the Clients
            NetworkServer.Spawn(bullet1);
            NetworkServer.Spawn(bullet2);

            // If Weapon Pods are active
            if (weaponPods == 1)
            {
                GameObject bullet1Pod = (GameObject)LeanPool.Spawn(defaultBulletPodPrefab, podOneSpawn.position, podOneSpawn.rotation);
                GameObject bullet2Pod = (GameObject)LeanPool.Spawn(defaultBulletPodPrefab, podTwoSpawn.position, podTwoSpawn.rotation);
                defaultBulletPodPrefab.name = "bulletPod";

                NetworkServer.Spawn(bullet1Pod);
                NetworkServer.Spawn(bullet2Pod);
            }
        }

        //Wideshot
        if (powerup == 1)
        {
            // Create bullets from the prefabs
            GameObject wideBullet0 = (GameObject)LeanPool.Spawn(wideBullet0Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject wideBullet1 = (GameObject)LeanPool.Spawn(wideBullet1Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject wideBullet2 = (GameObject)LeanPool.Spawn(wideBullet2Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject wideBullet3 = (GameObject)LeanPool.Spawn(wideBullet3Prefab, bulletSpawn.position, bulletSpawn.rotation);
            wideBullet0Prefab.name = "wideBullet0";
            wideBullet1Prefab.name = "wideBullet1";
            wideBullet2Prefab.name = "wideBullet2";
            wideBullet3Prefab.name = "wideBullet3";
            // Spawn the bullet on the Clients
            NetworkServer.Spawn(wideBullet0);
            NetworkServer.Spawn(wideBullet1);
            NetworkServer.Spawn(wideBullet2);
            NetworkServer.Spawn(wideBullet3);

            // If Weapon Pods are active
            if (weaponPods == 1)
            {
                GameObject wideBullet1Pod = (GameObject)LeanPool.Spawn(wideBulletPodPrefab, podOneSpawn.position, podOneSpawn.rotation);
                GameObject wideBullet2Pod = (GameObject)LeanPool.Spawn(wideBulletPodPrefab, podTwoSpawn.position, podTwoSpawn.rotation);
                wideBulletPodPrefab.name = "wideBulletPod";

                NetworkServer.Spawn(wideBullet1Pod);
                NetworkServer.Spawn(wideBullet2Pod);
            }
        }

        //Autofire
        if (powerup == 2)
        {
            // Create bullets from the prefabs
            GameObject autoBullet1 = (GameObject)LeanPool.Spawn(autoBullet1Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject autoBullet2 = (GameObject)LeanPool.Spawn(autoBullet2Prefab, bulletSpawn.position, bulletSpawn.rotation);
            autoBullet1Prefab.name = "autoBullet1";
            autoBullet2Prefab.name = "autoBullet2";
            // Spawn the bullet on the Clients
            NetworkServer.Spawn(autoBullet1);
            NetworkServer.Spawn(autoBullet2);

            // If Weapon Pods are active
            if (weaponPods == 1)
            {
                GameObject autoBullet1Pod = (GameObject)LeanPool.Spawn(autoBulletPodPrefab, podOneSpawn.position, podOneSpawn.rotation);
                GameObject autoBullet2Pod = (GameObject)LeanPool.Spawn(autoBulletPodPrefab, podTwoSpawn.position, podTwoSpawn.rotation);
                autoBulletPodPrefab.name = "autoBulletPod";

                NetworkServer.Spawn(autoBullet1Pod);
                NetworkServer.Spawn(autoBullet2Pod);
            }
        }

        //Sonic Pulse
        if (powerup == 3)
        {
            // Create pulses from the prefabs
            GameObject pulse1 = (GameObject)LeanPool.Spawn(sonicPrefab, bulletSpawn.position, bulletSpawn.rotation);
            sonicPrefab.name = "pulse1";
            // Spawn the pulse on the Clients
            NetworkServer.Spawn(pulse1);
        }
        
        //Rockets
        if (powerup == 4)
        {
            // Create rockets from the prefabs
            GameObject rocket1 = (GameObject)LeanPool.Spawn(rocketPrefab, rocketSpawn.position, rocketSpawn.rotation);
            rocketPrefab.name = "rocket1";
            // Spawn the rocket on the Clients
            NetworkServer.Spawn(rocket1);

            // If Weapon Pods are active
            if (weaponPods == 1)
            {
                GameObject rocket0 = (GameObject)LeanPool.Spawn(rocketPod1Prefab, podOneSpawn.position, podOneSpawn.rotation);
                GameObject rocket2 = (GameObject)LeanPool.Spawn(rocketPod2Prefab, podTwoSpawn.position, podTwoSpawn.rotation);
                rocketPod1Prefab.name = "rocket0";
                rocketPod2Prefab.name = "rocket2";

                // Spawn the rocket on the Clients
                NetworkServer.Spawn(rocket0);
                NetworkServer.Spawn(rocket2);
            }
        }
    }

    //Rocket fuse
    [Command]
    void CmdLite()
    {
        //Lights for Autofire
        if (powerup == 2)
        {
            GameObject bulletLight1 = (GameObject)LeanPool.Spawn(blueBulletLightPrefab, bulletSpawn.position, bulletSpawn.rotation);
            blueBulletLightPrefab.name = "bulletLight1";
            // Spawn the bullet on the Clients
            NetworkServer.Spawn(bulletLight1);
        }

        //Lights up Rockets
        if (powerup == 4)
        {
            rocket = GameObject.Find("rocket1");
            rocketPod1 = GameObject.Find("rocket0");
            rocketPod2 = GameObject.Find("rocket2");
            if (rocket != null)
            {
                playerRockets rocket1 = rocket.GetComponent<playerRockets>();

                rocket1.lit = 1;

                rocket1.name = "rocketLit1";
            }

            if (rocketPod1 != null)
            {
                playerRocketsPod1 rocket0 = rocketPod1.GetComponent<playerRocketsPod1>();

                rocket0.lit = 1;

                rocket0.name = "rocketLit0";
            }

            if (rocketPod2 != null)
            {
                playerRocketsPod2 rocket2 = rocketPod2.GetComponent<playerRocketsPod2>();

                rocket2.lit = 1;

                rocket2.name = "rocketLit2";
            }
        }
    }

    //Collisions
    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();
        powerupStar powerupStar = hit.GetComponent<powerupStar>();
        pickupPods pickupPods = hit.GetComponent<pickupPods>();

        //Eat shit and die
        if (health != null)
        {
            health.TakeDamage(dmg);
            alive = 0;
        }

        //Get Weapon Pods
        if (pickupPods != null)
        {
            weaponPods = 1;
        }

        //Get Powerup
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
