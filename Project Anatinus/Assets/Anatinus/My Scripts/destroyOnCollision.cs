using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnCollision : MonoBehaviour
{
    public GameObject scenery;
    public Transform scenerySpawn;
    public int endPoint = 20;
    //public bool isCreated = false;


    void Update()
    {
        if (transform.position.x < endPoint)
        {
            Instantiate(scenery, scenerySpawn.position, scenerySpawn.rotation);
            Destroy(gameObject);
        }
    }
}
