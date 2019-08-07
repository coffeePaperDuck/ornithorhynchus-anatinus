using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointsOnDisable : MonoBehaviour
{
    public int points;
    public GameObject bonus;

    //this is so that when the game starts, it does not give you the bonus/points as soon as the objects with this script load into the level
    public bool eligible = false;
    void Start()
    {
        eligible = true;
    }

    void Update()
    {
        if (bonus != null)
        {
            bonus.transform.position = this.transform.position;
        }
    }

    void OnDisable()
    {
        if (eligible == true)
        {
            //activate bonus
            if (bonus != null)
            {
                bonus.SetActive(true);
            }

            //activate points
            if (points != 0)
            {
                ScoreScript.scoreValue += points;
            }
        }
    }
}
