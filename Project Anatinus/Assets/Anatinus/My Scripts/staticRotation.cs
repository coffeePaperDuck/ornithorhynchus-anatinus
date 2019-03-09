using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticRotation : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    void Update()
    {
        transform.eulerAngles = new Vector3(x, y, z);
    }
}
