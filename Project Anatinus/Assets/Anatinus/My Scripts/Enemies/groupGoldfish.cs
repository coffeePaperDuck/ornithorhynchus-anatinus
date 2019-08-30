using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groupGoldfish : MonoBehaviour
{
    public float spawnTimer;
    public float spawnTimerSpeed;
    public int spawnCount = 0;

    public GameObject goldfish1;
    public GameObject goldfish2;
    public GameObject goldfish3;
    //public GameObject goldfish4;
    //public GameObject goldfish5;

    public GameObject bonus;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCount == 3 && goldfish1.activeSelf == false && goldfish2.activeSelf == false && goldfish3.activeSelf == false /*&& goldfish4.activeSelf == false && goldfish5.activeSelf == false*/)
        { bonus.SetActive(true); }

        if (goldfish1.activeSelf == true)
        { bonus.transform.position = goldfish1.transform.position; }
        if (goldfish2.activeSelf == true)
        { bonus.transform.position = goldfish2.transform.position; }
        if (goldfish3.activeSelf == true)
        { bonus.transform.position = goldfish3.transform.position; }
        /*if (goldfish4.activeSelf == true)
        { bonus.transform.position = goldfish4.transform.position; }
        if (goldfish5.activeSelf == true)
        { bonus.transform.position = goldfish5.transform.position; }*/

        spawnTimer += spawnTimerSpeed * Time.deltaTime;

        if (spawnTimer > 0 & spawnCount == 0)
        {
            goldfish1.SetActive(true);
            spawnCount = 1;
        }
        if (spawnTimer > 1 & spawnCount == 1)
        {
            goldfish2.SetActive(true);
            spawnCount = 2;
        }
        if (spawnTimer > 2 & spawnCount == 2)
        {
            goldfish3.SetActive(true);
            spawnCount = 3;
        }
        /* if (spawnTimer > 0.3 & spawnCount == 3)
         {
             goldfish4.SetActive(true);
             spawnCount = 4;
         }
         if (spawnTimer > 0.4 & spawnCount == 4)
         {
             goldfish5.SetActive(true);
             spawnCount = 5;
         }*/
    }
}
