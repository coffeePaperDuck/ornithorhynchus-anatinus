using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player1_scoreScript : MonoBehaviour
{
    public GameObject player1_score;
    public static int scoreValue = 0000000;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        player1_score = GameObject.Find("player1_score");
        //player1_score.SimpleHelvetica.Text = "0000000" +scoreValue;
    }
}
