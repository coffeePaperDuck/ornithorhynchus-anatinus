using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPoints : MonoBehaviour
{
    public int points;
    bool eligible = false;
    // Start is called before the first frame update
    void Start()
    {
        eligible = true;
    }

    // Update is called once per frame
    void OnDisable()
    {
        if (eligible == true)
        {
            ScoreScript.scoreValue += points;
        }
    }
}