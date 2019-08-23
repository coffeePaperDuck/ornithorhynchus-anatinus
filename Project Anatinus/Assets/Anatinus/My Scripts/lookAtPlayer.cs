using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    GameObject target;

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Player");
        transform.LookAt(target.transform);
    }
}
