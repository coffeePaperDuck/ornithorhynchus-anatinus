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
        /*if (timer > 20 && timer < 21 && !GameObject.Find("redSaucerGroupSpawned1"))
        {
            redSaucersPrefab.transform.position = spawnPosition;
            redSaucersPrefab.name = "redSaucerGroupSpawned1";
        }*/

        if (timer > 5 && timer < 6)
        { goldfishesPrefab.SetActive(true); }

        if (timer > 10 && timer < 11)
        { saucersPrefab.SetActive(true); }
    }
}