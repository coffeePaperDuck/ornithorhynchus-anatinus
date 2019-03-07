using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeaponPods : MonoBehaviour
{
    public float timer = 0.0f;
    public float speed = 8.0f;
    public float rot = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(rot, 0, 0);
        rot += 180 * Time.deltaTime;
    }
}
