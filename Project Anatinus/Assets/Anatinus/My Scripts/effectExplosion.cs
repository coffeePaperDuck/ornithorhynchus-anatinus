using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectExplosion : MonoBehaviour
{
    public GameObject explosion;
    void OnDisable()
    {
        Instantiate(explosion, this.transform.position, this.transform.rotation);
    }
}
