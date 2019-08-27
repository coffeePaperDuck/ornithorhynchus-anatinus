﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectExplosion : MonoBehaviour
{
    public GameObject explosion;

    //this is so that when the game starts, it does not activate as soon as the objects with this script load into the level
    public bool eligible = false;

    // Start is called before the first frame update
    void Start()
    {
        eligible = true;
    }

    void OnDisable()
    {
        Instantiate(explosion, this.transform.position, this.transform.rotation);
    }
}
