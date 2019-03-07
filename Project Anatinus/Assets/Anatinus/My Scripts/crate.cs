﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Lean.Pool;

public class crate : NetworkBehaviour
{
    public Transform spawn;

    public GameObject weaponPodsPrefab;
    public GameObject pointsDoublerPrefab;
    public GameObject coinsPrefab;
    public GameObject powerupPrefab;
    public GameObject powerup1Prefab;
    public GameObject powerup2Prefab;
    public GameObject powerup3Prefab;
    public GameObject powerup4Prefab;
    public GameObject powerup5Prefab;
    public GameObject minesPrefab;

    public int weaponPods;
    public int pointsDoubler;
    public int coins;
    public int powerup;
    public int powerup1;
    public int powerup2;
    public int powerup3;
    public int powerup4;
    public int powerup5;
    public int mines;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnDisable()
    {
        if (weaponPods != 0)
        {
            Instantiate(weaponPodsPrefab);
        }

        if (pointsDoubler != 0)
        {
            Instantiate(pointsDoublerPrefab);
        }

        if (coins != 0)
        {
            Instantiate(coinsPrefab);
        }
        
        if (powerup != 0)
        {
            GameObject powerup = (GameObject)LeanPool.Spawn(powerupPrefab, spawn.position, spawn.rotation);
            powerupPrefab.name = "powerup";
            NetworkServer.Spawn(powerup);
        }
        
    }
}