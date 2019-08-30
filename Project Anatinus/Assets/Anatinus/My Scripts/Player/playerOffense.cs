//birthed by logan
using System.Collections;
using System.Collections.Generic;
using Anatinus.My_Scripts.Gameplay;
using UnityEngine;

public class playerOffense : MonoBehaviour
{
    private float _timeSpeed = 1;
    
    //public int alive = 1;
    //public int lives = 4;
    //float _respawnTimer = 1.5f;

    //Whether powerups are active or not, + powerup timer.
    public int powerup = 0;
    public int powerupTimer = 0;

    //Whether weapon pods/points doublers are active or not.
    public int weaponPods = 0;
    public int pointsDoubler = 0;
    
    float kamikazeDmg = 84;

    //Bullet spawns
    public Transform bulletSpawn;
    public Transform rocketSpawn;
    public Transform podOneSpawn;
    public Transform podTwoSpawn;

    //Weapon Pods & Points Doubler game objects
    public GameObject weaponPodsPrefab;
    //public GameObject pointsDoublerPrefab; CURRENTLY UNUSED!

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
    //Autofire functionality
    public int autofireBulletCount;
    public float autofireTimerMax = 0.05f;
    public float autofireTimer = 0.05f;

    //Sonic pulse object
    public GameObject sonicPrefab;
    //Sonic pulse functionality
    public int pulseCountMax = 3;
    public int pulseCount;
    public float pulseTimerMax = 0.5f;
    public float pulseTimer;

    //Rocket objects
    public GameObject rocketPrefab;
    public GameObject rocketPod1Prefab;
    public GameObject rocketPod2Prefab;
    
    private GameObject _rocket;
    private GameObject _rocketPod1;
    private GameObject _rocketPod2;

    //Lightning object
    //public GameObject lightningPrefab; CURRENTLY UNUSED!


    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Update is called once per frame
    void Update()
    {
        //Essentials
        var dt = Time.deltaTime;
        var tf = transform;

        //Execute the code below if alive
        //if (alive > 0)
        //{
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

            //Lock axes listed below (Z axis is typically locked to keep the object on the 2D plane)
            Vector3 axis = tf.position;
            /*Z axis*/ axis.z = 0;
            tf.position = axis;

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
                autofireTimer += _timeSpeed * Time.deltaTime;
            }
            if (autofireTimer > autofireTimerMax && autofireBulletCount != 0)
            {
                autofireTimer = 0;
                autofireBulletCount -= 1;
                CmdFire();
            }

            //Refill Sonic Pulse
            if (pulseCount != pulseCountMax)
            {
                pulseTimer += _timeSpeed * Time.deltaTime;
            }
            if (pulseTimer > pulseTimerMax && pulseCount != pulseCountMax)
            {
                pulseTimer = 0;
                pulseCount += 1;

            }

            //Rocketman
            if (!Input.GetKey(KeyCode.RightControl))
            {
                _rocket = GameObject.Find("rocket(Clone)");
                _rocketPod1 = GameObject.Find("rocketPod1(Clone)");
                _rocketPod2 = GameObject.Find("rocketPod2(Clone)");
                if (_rocket != null)
                {
                    playerRockets rocketComponents = _rocket.GetComponent<playerRockets>();
                    rocketComponents.lit = 1;
                    rocketComponents.name = "rocketLit";
                }

                if (_rocketPod1 != null)
                {
                    playerRocketsPod1 rocketPod1Components = _rocketPod1.GetComponent<playerRocketsPod1>();
                    rocketPod1Components.lit = 1;
                    rocketPod1Components.name = "rocketPod1Lit";
                }

                if (_rocketPod2 != null)
                {
                    playerRocketsPod2 rocketPod2Components = _rocketPod2.GetComponent<playerRocketsPod2>();
                    rocketPod2Components.lit = 1;
                    rocketPod2Components.name = "rocketPod2Lit";
                }
            }
        //}

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
        /*if (alive < 1 && lives > 0)
        {
            _respawnTimer -= 1.0f * Time.deltaTime;
            if (_respawnTimer < 0)
            {
                alive = 1;
                lives -= 1;

                powerup = 0;
                weaponPods = 0;
                pointsDoubler = 0;

                _respawnTimer = 1.5f;
            }
        }*/
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Command to fire bullets
    void CmdFire()
    {
        //Essentials
        var shootPos = bulletSpawn.position;
        var shootRot = bulletSpawn.rotation;
        
        var podOnePos = podOneSpawn.position;
        var podOneRot = podOneSpawn.rotation;
        
        var podTwoPos = podTwoSpawn.position;
        var podTwoRot = podTwoSpawn.rotation;
        
        //Default
        if (powerup == 0)
        {
            // Create bullets from the prefabs
            GameObject bullet1 = (GameObject)Instantiate(defaultBullet1Prefab, shootPos, shootRot);
            GameObject bullet2 = (GameObject)Instantiate(defaultBullet2Prefab, shootPos, shootRot);
            defaultBullet1Prefab.name = "bullet1";
            defaultBullet2Prefab.name = "bullet2";

            // If Weapon Pods are active
            if (weaponPods == 1)
            {
                GameObject bullet1Pod = (GameObject)Instantiate(defaultBulletPodPrefab, podOnePos, podOneRot);
                GameObject bullet2Pod = (GameObject)Instantiate(defaultBulletPodPrefab, podTwoPos, podTwoRot);
                defaultBulletPodPrefab.name = "bulletPod";
            }
        }

        //Wideshot
        if (powerup == 1)
        {
            // Create bullets from the prefabs
            GameObject wideBullet0 = (GameObject)Instantiate(wideBullet0Prefab, shootPos, shootRot);
            GameObject wideBullet1 = (GameObject)Instantiate(wideBullet1Prefab, shootPos, shootRot);
            GameObject wideBullet2 = (GameObject)Instantiate(wideBullet2Prefab, shootPos, shootRot);
            GameObject wideBullet3 = (GameObject)Instantiate(wideBullet3Prefab, shootPos, shootRot);
            wideBullet0Prefab.name = "wideBullet0";
            wideBullet1Prefab.name = "wideBullet1";
            wideBullet2Prefab.name = "wideBullet2";
            wideBullet3Prefab.name = "wideBullet3";

            // If Weapon Pods are active
            if (weaponPods == 1)
            {
                GameObject wideBullet1Pod = (GameObject)Instantiate(wideBulletPodPrefab, podOnePos, podOneRot);
                GameObject wideBullet2Pod = (GameObject)Instantiate(wideBulletPodPrefab, podTwoPos, podTwoRot);
                wideBulletPodPrefab.name = "wideBulletPod";
            }
        }

        //Autofire
        if (powerup == 2)
        {
            // Create bullets from the prefabs
            GameObject autoBullet1 = (GameObject)Instantiate(autoBullet1Prefab, shootPos, shootRot);
            GameObject autoBullet2 = (GameObject)Instantiate(autoBullet2Prefab, shootPos, shootRot);
            autoBullet1Prefab.name = "autoBullet1";
            autoBullet2Prefab.name = "autoBullet2";

            // If Weapon Pods are active
            if (weaponPods == 1)
            {
                GameObject autoBullet1Pod = (GameObject)Instantiate(autoBulletPodPrefab, podOnePos, podOneRot);
                GameObject autoBullet2Pod = (GameObject)Instantiate(autoBulletPodPrefab, podTwoPos, podTwoRot);
                autoBulletPodPrefab.name = "autoBulletPod";
            }
        }

        //Sonic Pulse
        if (powerup == 3)
        {
            // Create pulses from the prefabs
            GameObject pulse1 = (GameObject)Instantiate(sonicPrefab, shootPos, shootRot);
            sonicPrefab.name = "pulse1";
        }
        
        //Rockets
        if (powerup == 4)
        {
            // Create rockets from the prefabs
            GameObject rocket1 = (GameObject)Instantiate(rocketPrefab, rocketSpawn.position, rocketSpawn.rotation);
            rocketPrefab.name = "rocket";

            // If Weapon Pods are active
            if (weaponPods == 1)
            {
                GameObject rocket0 = (GameObject)Instantiate(rocketPod1Prefab, podOnePos, podOneRot);
                GameObject rocket2 = (GameObject)Instantiate(rocketPod2Prefab, podTwoPos, podTwoRot);
                rocketPod1Prefab.name = "rocketPod1";
                rocketPod2Prefab.name = "rocketPod2";
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

        //If the collided object has health
        if (health != null)
        {
            //Deal kamikaze damage to the collided object
            health.TakeDamage(kamikazeDmg);

            //Kill the player
            //alive = 0;
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
