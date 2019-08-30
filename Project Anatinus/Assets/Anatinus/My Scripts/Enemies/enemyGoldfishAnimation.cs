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
    private MeshFilter _meshFilter;
    private MeshFilter _meshFilter1;

    // Update is called once per frame
    private void Start()
    {
        _meshFilter1 = GetComponent<MeshFilter>();
        _meshFilter = GetComponent<MeshFilter>();
    }

    void Update ()
    {
        timer += timerSpeed * Time.deltaTime;
        if (timer > timerCheckpoint1)
        {
            _meshFilter.mesh = goldfish2Prefab;
        }
        if (timer > timerCheckpoint2)
        {
            _meshFilter1.mesh = goldfish1Prefab;
        }
    }
}
