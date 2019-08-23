using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingMissile : MonoBehaviour
{
    public float rotTimer;
    public float rot;
    public float rotSpeed;
    public float speed = 10;

    public float dirTimer;
    public int yDirection;

    public GameObject target;
    public GameObject pointPrefab;
    public GameObject radiusAbovePrefab;
    public GameObject radiusBelowPrefab;
    // Start is called before the first frame update
    void OnEnable()
    {
        rot = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        dirTimer += 1 * Time.deltaTime;
        if (dirTimer > 0.5f)
        {
            transform.eulerAngles = new Vector3(0, 0, rot);
            if (yDirection == 1)
            { rotSpeed = 11.25f; }
            if (yDirection == -1)
            { rotSpeed = -11.25f; }

            rotTimer += 24 * Time.deltaTime;
            if (rotTimer > 1.0f)
            {
                rot += rotSpeed;
                rotTimer = 0.0f;
            }
        }
    }
}
