using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        homingMissile missile = transform.root.gameObject.GetComponent<homingMissile>();

        if (collision.gameObject.name == "radiusAbove")
        {
            missile.yDirection = 1;
        }

        if (collision.gameObject.name == "radiusBelow")
        {
            missile.yDirection = -1;
        }
    }
}
