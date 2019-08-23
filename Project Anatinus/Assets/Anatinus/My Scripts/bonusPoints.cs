using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusPoints : MonoBehaviour
{
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        ScoreScript.scoreValue += points;
    }
}
