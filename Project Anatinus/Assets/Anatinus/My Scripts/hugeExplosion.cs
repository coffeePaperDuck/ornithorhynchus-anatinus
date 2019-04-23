using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hugeExplosion : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void OnDisable()
    {
        Instantiate(explosion, this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
