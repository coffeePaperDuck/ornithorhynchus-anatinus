using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGoldfishAnimation : MonoBehaviour
{
    public float timer = 0.0f;
    public Mesh goldfish1Prefab;
    public Mesh goldfish2Prefab;
    public Mesh goldfish3Prefab;

	// Update is called once per frame
	void Update ()
    {
        timer += 1.0f * Time.deltaTime;
        if (timer > 2.0f)
        {
            GetComponent<MeshFilter>().mesh = goldfish2Prefab;
        }
        if (timer > 2.5f)
        {
            GetComponent<MeshFilter>().mesh = goldfish1Prefab;
        }
    }
}
