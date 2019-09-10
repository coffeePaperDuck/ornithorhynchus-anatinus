using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
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
