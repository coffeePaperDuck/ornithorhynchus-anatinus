using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debrisOnDisable : MonoBehaviour
{
    public GameObject debris;

    //this is so that when the game starts, it does not activate as soon as the objects with this script load into the level
    public bool eligible = false;

    void Start()
    {
        eligible = true;
    }

    void Update()
    {

            debris.transform.position = this.transform.position;
    }

    void OnDisable()
    {
        if (eligible == true)
        {
                debris.SetActive(true);
        }
    }
}
