using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class testLevelScript : MonoBehaviour
{
    public float timer;
    public float timerSpeed = 1;

    public GameObject redSaucersPrefab;
    public GameObject goldfishesPrefab;
    public GameObject saucersPrefab;

    int spawnPointY = Random.Range(-4, 4);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spawnPosition = new Vector3(20, spawnPointY, 0);

        timer += timerSpeed * Time.deltaTime;

        //LEVEL TIMES//
        if (timer > 3 && timer < 4 && !GameObject.Find("redSaucerGroupSpawned1"))
        {
            redSaucersPrefab.transform.position = spawnPosition;
            redSaucersPrefab.name = "redSaucerGroupSpawned1";
        }
    }
}