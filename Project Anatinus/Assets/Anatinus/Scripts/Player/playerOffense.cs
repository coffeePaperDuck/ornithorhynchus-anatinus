//birthed by logan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOffense : MonoBehaviour
{
    private float _timeSpeed = 1;
    
    //Whether powerups are active or not, + powerup timer.
    public int powerup = 0;
    private float _powerupTimer;

    //Whether weapon pods/points doublers are active or not.
    public int weaponPods = 0;
    private int pointsDoubler = 0;

    //Damage values
    public float attackDmg;
    float kamikazeDmg = 84;

    //Bullet spawns
    public Transform bulletSpawn; //Spawns bullets at the front of the ship
    public Transform rocketSpawn; //Spawns rockets at the bottom of the ship
    public Transform podOneSpawn; //Spawns any shots at the first weapon pod
    public Transform podTwoSpawn; //Spawns any shots at the second weapon pod

    //Weapon Pods & Points Doubler game objects
    public GameObject weaponPodsPrefab;
    private GameObject pointsDoublerPrefab;

    //Weapons
    public GameObject bulletPrefab; //Bullet objects
    public GameObject pulsePrefab; //Sonic pulse object
    public GameObject rocketPrefab; //Rocket objects

    //Autofire functionality
    private int autofireBulletCount;
    private float autofireTimer = 0.05f;

    //Sonic pulse functionality
    private int pulseCount;
    private float pulseTimer;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Command to fire bullets
    void Fire()
    {
        //Essentials
        var shootPos = bulletSpawn.position;
        var shootRot = bulletSpawn.rotation;

        var podOnePos = podOneSpawn.position;
        var podOneRot = podOneSpawn.rotation;

        var podTwoPos = podTwoSpawn.position;
        var podTwoRot = podTwoSpawn.rotation;

        if (powerup > -1 && powerup < 3)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // All bullets

            // Create bullets from the prefabs
            GameObject bullet1Spawned = (GameObject)Instantiate(bulletPrefab, shootPos, shootRot); //spawn bullet 1
            GameObject bullet2Spawned = (GameObject)Instantiate(bulletPrefab, shootPos, shootRot); //spawn bullet 2
            if (weaponPods == 1) // If Weapon Pods are active
            {
                GameObject bulletPod1 = (GameObject)Instantiate(bulletPrefab, podOnePos, podOneRot); //spawn pod bullet 1
                GameObject bulletPod2 = (GameObject)Instantiate(bulletPrefab, podTwoPos, podTwoRot); //spawn pod bullet 2
            }
            playerBullets bullets = bulletPrefab.GetComponent<playerBullets>(); //get script of all bullets
            playerBullets bullet1 = bullet1Spawned.GetComponent<playerBullets>(); //get script of bullet 1
            playerBullets bullet2 = bullet2Spawned.GetComponent<playerBullets>(); //get script of bullet 2

            bullets.dmg = attackDmg; //set all bullets damage values
            bullet1.ySpeed = 1; //set bullet 1's ySpeed  |^ -
            bullet2.ySpeed = -1; //set bullet 2's ySpeed |v -

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // Wideshot bullets
            if (powerup == 1)
            {
                // Create bullets from the prefabs
                GameObject bullet0Spawned = (GameObject)Instantiate(bulletPrefab, shootPos, shootRot); //spawn bullet 0
                GameObject bullet3Spawned = (GameObject)Instantiate(bulletPrefab, shootPos, shootRot); //spawn bullet 3
                playerBullets bullet0 = bullet0Spawned.GetComponent<playerBullets>(); //get script of bullet 0
                playerBullets bullet3 = bullet3Spawned.GetComponent<playerBullets>(); //get script of bullet 3

                bullets.wide = true; //set all bullets to wide
                bullet0.rotation = 15; //set bullet 0's rotation  |^ /
                bullet3.rotation = -15; //set bullet 3's rotation |v \
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Sonic Pulse
        if (powerup == 3)
        {
            // Create pulses from the prefabs
            GameObject pulseSpawned = (GameObject)Instantiate(this.pulsePrefab, shootPos, shootRot);
            playerPulse pulse = pulseSpawned.GetComponent<playerPulse>(); //get script of pulse
            pulse.dmg = attackDmg; //set pulse damage value
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Rockets
        if (powerup == 4)
        {
            // Create rockets from the prefabs
            GameObject rocket1 = (GameObject)Instantiate(rocketPrefab, rocketSpawn.position, rocketSpawn.rotation); //spawn rocket 1
            if (weaponPods == 1) // If Weapon Pods are active
            {
                GameObject rocket0 = (GameObject)Instantiate(rocketPrefab, podOnePos, podOneRot); //spawn rocket 0
                GameObject rocket2 = (GameObject)Instantiate(rocketPrefab, podTwoPos, podTwoRot); //spawn rocket 2
            }
            playerPulse rocket = rocketPrefab.GetComponent<playerPulse>(); //get script of all rockets
            rocket.dmg = attackDmg; //set all rockets damage values
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Update is called once per frame
    void Update()
    {
        //Essentials
        var dt = Time.deltaTime;
        var tf = transform;

        //Activate Powerups (Testing Code)
        if (Input.GetKeyDown(KeyCode.F1))
        { powerup = 0; }
        if (Input.GetKeyDown(KeyCode.F2))
        { powerup = 1; }
        if (Input.GetKeyDown(KeyCode.F3))
        { powerup = 2; }
        if (Input.GetKeyDown(KeyCode.F4))
        { powerup = 3; }
        if (Input.GetKeyDown(KeyCode.F5))
        { powerup = 4; }
        if (Input.GetKeyDown(KeyCode.F6))
        { powerup = 5; }

        //Damage values
        if (powerup == 0)
        { attackDmg = 2f; }

        if (powerup == 1)
        { attackDmg = 1f; }

        if (powerup == 2)
        { attackDmg = 1.7f; }

        if (powerup == 3)
        { attackDmg = 3f; }

        if (powerup == 4)
        { attackDmg = 9.5f; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // If the fire key is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            //Autofire
            if (powerup == 2) //If powerup is autofire
            {
                if (autofireBulletCount < 5)
                { autofireBulletCount += 5; }
            }

            //Sonic Pulse
            if (powerup == 3) //If powerup is sonic pulse
            {
                if (pulseCount != 0)
                {
                    pulseCount -= 1;
                    Fire();
                }
            }

            //Anything else
            if (powerup != 2 && powerup != 3)
            { Fire(); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Keep Autofire refilled
        if (autofireTimer < 0.05f * 2)
        { autofireTimer += _timeSpeed*dt; }

        if (autofireTimer > 0.05f && autofireBulletCount != 0)
        {
            autofireTimer = 0;
            autofireBulletCount -= 1;
            Fire();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Refill Sonic Pulse
        if (pulseCount != 3)
        { pulseTimer += _timeSpeed*dt; }

        if (pulseTimer > 0.5f && pulseCount != 3)
        {
            pulseTimer = 0;
            pulseCount += 1;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Weapon Pods
        if (weaponPods == 1)
        { weaponPodsPrefab.SetActive(true); } else { weaponPodsPrefab.SetActive(false); }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Collisions
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
        { weaponPods = 1; } //Provide weapon pods

        //If the collided object is able to provide powerups
        if (powerupStar != null)
        {
            //If the powerup timers are between the values below
            if (powerupStar.powerup > 0 && powerupStar.powerup < 1.5)
            { powerup = 1; } //Provide wideshot

            if (powerupStar.powerup > 1.5 && powerupStar.powerup < 2.5)
            { powerup = 2; } //Provide autofire

            if (powerupStar.powerup > 2.5 && powerupStar.powerup < 3.5)
            { powerup = 3; } //Provide pulse

            if (powerupStar.powerup > 3.5 && powerupStar.powerup < 4.5)
            { powerup = 4; } //Provide rockets

            if (powerupStar.powerup > 4.5 && powerupStar.powerup < 5.5)
            { powerup = 1; } //Provide wideshot
        }
    }
}
