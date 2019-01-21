using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGoldfish : MonoBehaviour
{
    public float timer = 0.0f;
    public Mesh goldfish1prefab;
    public Mesh goldfish2prefab;
    public Mesh goldfish3prefab;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += 1.0f * Time.deltaTime;
        if (timer > 1.0f)
        {
            GetComponent<MeshFilter>().mesh = goldfish2prefab;
        }
        if (timer > 2.0f)
        {
            GetComponent<MeshFilter>().mesh = goldfish1prefab;
        }
    }
}
