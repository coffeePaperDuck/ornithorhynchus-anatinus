using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLevelScript : MonoBehaviour
{
    public float timer;
    public float timerSpeed = 1;

    public int timesIndex = 0;

    [SerializeField]
    public List<GameObject> enemies;

    [SerializeField]
    public List<float> times;

    // public List<string> Enemies;

    int spawnPointY = Random.Range(-5, 5);


    // Update is called once per frame
    void Update()
    {
        spawnPointY = Random.Range(-5, 5);
        Vector3 spawnPosition = new Vector3(15, spawnPointY, 0);

        timer += timerSpeed * Time.deltaTime;

        //Spawn enemies according to the times set on the level script in the Unity Inspector.//
        if (timer > times[timesIndex])
        {
            enemies[timesIndex].transform.position = spawnPosition;
            timesIndex += 1;
        }

    }
}