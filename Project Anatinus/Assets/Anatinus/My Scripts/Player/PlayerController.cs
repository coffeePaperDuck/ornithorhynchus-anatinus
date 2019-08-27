//birthed by logan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int alive = 1;
    public int lives = 4;
    public float respawnTimer = 1.5f;

    //Whether powerups are active or not, + powerup timer.
    public int powerup = 0;
    public int powerupTimer = 0;

    //Whether weapon pods/points doublers are active or not.
    public int weaponPods = 0;
    public int pointsDoubler = 0;


    public float dmg;
    public float speed = 10.0f;

    //Animation stuff
    int tilt = 0; //Is applied to X rotation, makes it look like the ship is tilting when moving (via "ship animation tilts" code below)
    public float animationTimer = 2.5f; //Timer for ship tilting.

    //Bullet spawns
    public Transform bulletSpawn;
    public Transform rocketSpawn;
    public Transform centerOrbit;
    public Transform podOneSpawn;
    public Transform podTwoSpawn;

    //Weapon Pods & Points Doubler game objects
    public GameObject weaponPodsPrefab;
    public GameObject pointsDoublerPrefab;

    //Default bullet objects
    public GameObject defaultBullet1Prefab;
    public GameObject defaultBullet2Prefab;
    public GameObject defaultBulletPodPrefab;

    //Wideshot bullet objects
    public GameObject wideBullet0Prefab;
    public GameObject wideBullet1Prefab;
    public GameObject wideBullet2Prefab;
    public GameObject wideBullet3Prefab;
    public GameObject wideBulletPodPrefab;

    //Autofire bullet objects
    public GameObject autoBullet1Prefab;
    public GameObject autoBullet2Prefab;
    public GameObject autoBulletPodPrefab;
    public GameObject blueBulletLightPrefab; //Light source for Autofire, spawns every few streams of bullets instead of spawning for every bullet for optimization purposes.

    //Sonic pulse object
    public GameObject sonicPrefab;

    //Rocket objects
    public GameObject rocketPrefab;
    public GameObject rocketPod1Prefab;
    public GameObject rocketPod2Prefab;
    private GameObject rocket;
    private GameObject rocketPod1;
    private GameObject rocketPod2;

    //Lightning object
    public GameObject lightningPrefab;

    //Autofire functionality
    public int autofireBulletCount;
    public float autofireTimerMax = 1;
    public float autofireTimer = 1;
    public int autofireLightCount;
    public float autofireLightTimerMax = 1;
    public float autofireLightTimer = 1;

    //Sonic pulse functionality
    public int pulseCountMax = 3;
    public int pulseCount;
    public float pulseTimerMax = 0.5f;
    public float pulseTimer;


    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Update is called once per frame
    void Update()
    {
        //Execute the code below if alive
        if (alive > 0)
        {
            //Activate Powerups (Testing Code)
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
            if (animationTimer > 0.0f && animationTimer < 1.0f)
            { tilt = -30; }

            if (animationTimer > 1.0f && animationTimer < 2.0f)
            { tilt = -15; }

            if (animationTimer > 2.0f && animationTimer < 3.0f)
            { tilt = 0; }

            if (animationTimer > 3.0f && animationTimer < 4.0f)
            { tilt = 15; }

            if (animationTimer > 4.0f && animationTimer < 5.0f)
            { tilt = 30; }

            //boundaries
            //top 7.13
            //left -9.29
            //right 9.47
            //bottom -7.07

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // Move up
            if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 7.13)
            {
                transform.Translate(0, speed * Time.deltaTime, 0);

                //tilt the ship up when the up key is pressed
                if (animationTimer < 5.0f)
                { animationTimer += 10.0f * Time.deltaTime; }
            }
            //tilt the ship back down when up key is released
            if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) & animationTimer > 3.0f)
            {
                animationTimer -= 10.0f * Time.deltaTime;
            }


            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // Move left
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -9.29)
            {
                    transform.Translate(-speed * Time.deltaTime, 0, 0);
            }


            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // Move down
            if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -7.07)
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);

                //tilt the ship down when the down key is pressed
                if (animationTimer > 0)
                { animationTimer -= 10.0f * Time.deltaTime; }
            }
            //tilt the ship back up when the down key is released
            if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow) && animationTimer < 2.0f)
            {
                animationTimer += 10.0f * Time.deltaTime;
            }


            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // Move right
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 9.47)
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
                if (powerup != 2 && powerup != 3)
                {
                    CmdFire();
                }
            }

            //Keep Autofire refilled
            if (autofireTimer < autofireTimerMax * 2)
            {
                autofireTimer += 20.0f * Time.deltaTime;
            }
            if (autofireTimer > autofireTimerMax && autofireBulletCount != 0)
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
            if (autofireLightTimer > autofireLightTimerMax && autofireLightCount != 0)
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
            if (pulseTimer > pulseTimerMax && pulseCount != pulseCountMax)
            {
                pulseTimer = 0;
                pulseCount += 1;

            }

            //Rocketman
            if (Input.GetKeyUp(KeyCode.RightControl))
            {
                //if (powerup == 4)
                //{
                    CmdLite();
                //}
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
        if (alive < 1 && lives > 0)
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
    void CmdFire()
    {
        //Default
        if (powerup == 0)
        {
            // Create bullets from the prefabs
            GameObject bullet1 = (GameObject)Instantiate(defaultBullet1Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject bullet2 = (GameObject)Instantiate(defaultBullet2Prefab, bulletSpawn.position, bulletSpawn.rotation);
            defaultBullet1Prefab.name = "bullet1";
            defaultBullet2Prefab.name = "bullet2";
            // Spawn the bullet on the Clients
            //NetworkServer.Spawn(bullet1);
            //NetworkServer.Spawn(bullet2);

            // If Weapon Pods are active
            if (weaponPods == 1)
            {
                GameObject bullet1Pod = (GameObject)Instantiate(defaultBulletPodPrefab, podOneSpawn.position, podOneSpawn.rotation);
                GameObject bullet2Pod = (GameObject)Instantiate(defaultBulletPodPrefab, podTwoSpawn.position, podTwoSpawn.rotation);
                defaultBulletPodPrefab.name = "bulletPod";

                //NetworkServer.Spawn(bullet1Pod);
                //NetworkServer.Spawn(bullet2Pod);
            }
        }

        //Wideshot
        if (powerup == 1)
        {
            // Create bullets from the prefabs
            GameObject wideBullet0 = (GameObject)Instantiate(wideBullet0Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject wideBullet1 = (GameObject)Instantiate(wideBullet1Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject wideBullet2 = (GameObject)Instantiate(wideBullet2Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject wideBullet3 = (GameObject)Instantiate(wideBullet3Prefab, bulletSpawn.position, bulletSpawn.rotation);
            wideBullet0Prefab.name = "wideBullet0";
            wideBullet1Prefab.name = "wideBullet1";
            wideBullet2Prefab.name = "wideBullet2";
            wideBullet3Prefab.name = "wideBullet3";
            // Spawn the bullet on the Clients
            //NetworkServer.Spawn(wideBullet0);
            //NetworkServer.Spawn(wideBullet1);
            //NetworkServer.Spawn(wideBullet2);
            //NetworkServer.Spawn(wideBullet3);

            // If Weapon Pods are active
            if (weaponPods == 1)
            {
                GameObject wideBullet1Pod = (GameObject)Instantiate(wideBulletPodPrefab, podOneSpawn.position, podOneSpawn.rotation);
                GameObject wideBullet2Pod = (GameObject)Instantiate(wideBulletPodPrefab, podTwoSpawn.position, podTwoSpawn.rotation);
                wideBulletPodPrefab.name = "wideBulletPod";

                //NetworkServer.Spawn(wideBullet1Pod);
                //NetworkServer.Spawn(wideBullet2Pod);
            }
        }

        //Autofire
        if (powerup == 2)
        {
            // Create bullets from the prefabs
            GameObject autoBullet1 = (GameObject)Instantiate(autoBullet1Prefab, bulletSpawn.position, bulletSpawn.rotation);
            GameObject autoBullet2 = (GameObject)Instantiate(autoBullet2Prefab, bulletSpawn.position, bulletSpawn.rotation);
            autoBullet1Prefab.name = "autoBullet1";
            autoBullet2Prefab.name = "autoBullet2";
            // Spawn the bullet on the Clients
            //NetworkServer.Spawn(autoBullet1);
            //NetworkServer.Spawn(autoBullet2);

            // If Weapon Pods are active
            if (weaponPods == 1)
            {
                GameObject autoBullet1Pod = (GameObject)Instantiate(autoBulletPodPrefab, podOneSpawn.position, podOneSpawn.rotation);
                GameObject autoBullet2Pod = (GameObject)Instantiate(autoBulletPodPrefab, podTwoSpawn.position, podTwoSpawn.rotation);
                autoBulletPodPrefab.name = "autoBulletPod";

                //NetworkServer.Spawn(autoBullet1Pod);
                //NetworkServer.Spawn(autoBullet2Pod);
            }
        }

        //Sonic Pulse
        if (powerup == 3)
        {
            // Create pulses from the prefabs
            GameObject pulse1 = (GameObject)Instantiate(sonicPrefab, bulletSpawn.position, bulletSpawn.rotation);
            sonicPrefab.name = "pulse1";
            // Spawn the pulse on the Clients
            //NetworkServer.Spawn(pulse1);
        }
        
        //Rockets
        if (powerup == 4)
        {
            // Create rockets from the prefabs
            GameObject rocket1 = (GameObject)Instantiate(rocketPrefab, rocketSpawn.position, rocketSpawn.rotation);
            rocketPrefab.name = "rocket";
            // Spawn the rocket on the Clients
            //NetworkServer.Spawn(rocket1);

            // If Weapon Pods are active
            if (weaponPods == 1)
            {
                GameObject rocket0 = (GameObject)Instantiate(rocketPod1Prefab, podOneSpawn.position, podOneSpawn.rotation);
                GameObject rocket2 = (GameObject)Instantiate(rocketPod2Prefab, podTwoSpawn.position, podTwoSpawn.rotation);
                rocketPod1Prefab.name = "rocketPod1";
                rocketPod2Prefab.name = "rocketPod2";

                // Spawn the rocket on the Clients
                //NetworkServer.Spawn(rocket0);
                //NetworkServer.Spawn(rocket2);
            }
        }
    }

    //Rocket fuse
    void CmdLite()
    {
        //Lights for Autofire
        if (powerup == 2)
        {
            GameObject bulletLight1 = (GameObject)Instantiate(blueBulletLightPrefab, bulletSpawn.position, bulletSpawn.rotation);
            blueBulletLightPrefab.name = "bulletLight1";
            // Spawn the bullet on the Clients
            //NetworkServer.Spawn(bulletLight1);
        }

            rocket = GameObject.Find("rocket(Clone)");
            rocketPod1 = GameObject.Find("rocketPod1(Clone)");
            rocketPod2 = GameObject.Find("rocketPod2(Clone)");
            if (rocket != null)
            {
                playerRockets rocketComponents = rocket.GetComponent<playerRockets>();

                rocketComponents.lit = 1;

                rocketComponents.name = "rocketLit";
            }

            if (rocketPod1 != null)
            {
                playerRocketsPod1 rocketPod1Components = rocketPod1.GetComponent<playerRocketsPod1>();

                rocketPod1Components.lit = 1;

                rocketPod1Components.name = "rocketPod1Lit";
            }

            if (rocketPod2 != null)
            {
                playerRocketsPod2 rocketPod2Components = rocketPod2.GetComponent<playerRocketsPod2>();

                rocketPod2Components.lit = 1;

                rocketPod2Components.name = "rocketPod2Lit";
            }
    }

    //Collisions
    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();
        powerupStar powerupStar = hit.GetComponent<powerupStar>();
        pickupPods pickupPods = hit.GetComponent<pickupPods>();

        //If the collided object has health
        if (health != null)
        {
            //Deal kamikaze damage to the collided object
            health.TakeDamage(dmg);

            //Kill the player
            alive = 0;
        }

        //If the collided object is able to provide weapon pods
        if (pickupPods != null)
        {
            //Provide weapon pods
            weaponPods = 1;
        }

        //If the collided object is able to provide powerups
        if (powerupStar != null)
        {
            //If the powerup timers are between the values below
            if (powerupStar.powerup > 0 && powerupStar.powerup < 1.5)
            {
                //Provide wideshot
                powerup = 1;
            }

            if (powerupStar.powerup > 1.5 && powerupStar.powerup < 2.5)
            {
                //Provide autofire
                powerup = 2;
            }

            if (powerupStar.powerup > 2.5 && powerupStar.powerup < 3.5)
            {
                //Provide pulse
                powerup = 3;
            }

            if (powerupStar.powerup > 3.5 && powerupStar.powerup < 4.5)
            {
                //Provide rockets
                powerup = 4;
            }

            if (powerupStar.powerup > 4.5 && powerupStar.powerup < 5.5)
            {
                //Provide wideshot
                powerup = 1;
            }
        }
    }

}
