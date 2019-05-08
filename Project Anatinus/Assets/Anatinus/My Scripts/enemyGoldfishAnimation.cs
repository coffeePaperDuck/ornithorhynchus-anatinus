using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGoldfishAnimation : MonoBehaviour
{
    public float timer;
    public float timerSpeed = 1;
    public float timerCheckpoint1;
    public float timerCheckpoint2;
    public Mesh goldfish1Prefab;
    public Mesh goldfish2Prefab;
    public Mesh goldfish3Prefab;

	// Update is called once per frame
	void Update ()
    {
        timer += timerSpeed * Time.deltaTime;
        if (timer > timerCheckpoint1)
        {
            GetComponent<MeshFilter>().mesh = goldfish2Prefab;
        }
        if (timer > timerCheckpoint2)
        {
            GetComponent<MeshFilter>().mesh = goldfish1Prefab;
        }
    }
}
