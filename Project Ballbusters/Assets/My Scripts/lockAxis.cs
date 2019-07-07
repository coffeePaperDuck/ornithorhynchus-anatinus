using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockAxis : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //lock onto axises listed below
        Quaternion rot = transform.rotation;
        /*Z axis*/
        rot.x = 0;
        rot.y = 0;
        rot.z = 0;
        transform.rotation = rot;
    }
}
