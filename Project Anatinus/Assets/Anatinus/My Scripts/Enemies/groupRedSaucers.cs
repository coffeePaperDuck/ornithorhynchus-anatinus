using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groupRedSaucers : MonoBehaviour
{
    public bool execute = false;

    public float spawnTimer;
    public int spawnCount = 0;

    public GameObject saucerTop1;
    public GameObject saucerBottom1;

    public GameObject saucerTop2;
    public GameObject saucerBottom2;

    public GameObject saucerTop3;
    public GameObject saucerBottom3;

    public GameObject saucerTop4;
    public GameObject saucerBottom4;

    public GameObject saucerTop5;
    public GameObject saucerBottom5;

    public GameObject powerup;



    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {    
            execute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (execute == true)
        {
            if (spawnCount == 5 && saucerTop1.activeSelf == false && saucerBottom1.activeSelf == false && saucerTop2.activeSelf == false && saucerBottom2.activeSelf == false && saucerTop3.activeSelf == false && saucerBottom3.activeSelf == false && saucerTop4.activeSelf == false && saucerBottom4.activeSelf == false && saucerTop5.activeSelf == false && saucerBottom5.activeSelf == false)
            { powerup.SetActive(true); }

            if (saucerTop1.activeSelf == true)
            { powerup.transform.position = saucerTop1.transform.position; }
            if (saucerTop2.activeSelf == true)
            { powerup.transform.position = saucerTop2.transform.position; }
            if (saucerTop3.activeSelf == true)
            { powerup.transform.position = saucerTop3.transform.position; }
            if (saucerTop4.activeSelf == true)
            { powerup.transform.position = saucerTop4.transform.position; }
            if (saucerTop5.activeSelf == true)
            { powerup.transform.position = saucerTop5.transform.position; }

            if (saucerBottom1.activeSelf == true)
            { powerup.transform.position = saucerBottom1.transform.position; }
            if (saucerBottom2.activeSelf == true)
            { powerup.transform.position = saucerBottom2.transform.position; }
            if (saucerBottom3.activeSelf == true)
            { powerup.transform.position = saucerBottom3.transform.position; }
            if (saucerBottom4.activeSelf == true)
            { powerup.transform.position = saucerBottom4.transform.position; }
            if (saucerBottom5.activeSelf == true)
            { powerup.transform.position = saucerBottom5.transform.position; }

            spawnTimer += 1 * Time.deltaTime;

            if (spawnTimer > 0.1 & spawnCount == 0)
            {
                saucerTop1.GetComponent<enemySaucerReversed>().enabled = true;
                saucerBottom1.GetComponent<enemySaucer>().enabled = true;
                spawnCount = 1;
            }
            if (spawnTimer > 0.2 & spawnCount == 1)
            {
                saucerTop2.GetComponent<enemySaucerReversed>().enabled = true;
                saucerBottom2.GetComponent<enemySaucer>().enabled = true;
                spawnCount = 2;
            }
            if (spawnTimer > 0.3 & spawnCount == 2)
            {
                saucerTop3.GetComponent<enemySaucerReversed>().enabled = true;
                saucerBottom3.GetComponent<enemySaucer>().enabled = true;
                spawnCount = 3;
            }
            if (spawnTimer > 0.4 & spawnCount == 3)
            {
                saucerTop4.GetComponent<enemySaucerReversed>().enabled = true;
                saucerBottom4.GetComponent<enemySaucer>().enabled = true;
                spawnCount = 4;
            }
            if (spawnTimer > 0.5 & spawnCount == 4)
            {
                saucerTop5.GetComponent<enemySaucerReversed>().enabled = true;
                saucerBottom5.GetComponent<enemySaucer>().enabled = true;
                spawnCount = 5;
            }
        }
    }
}
