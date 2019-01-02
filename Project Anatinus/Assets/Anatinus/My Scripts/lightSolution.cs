using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSolution : MonoBehaviour
{
    public Light lighty;

    public bool changeColors = true;
    public float colorSpeed = 1.0f;
    public Color startColor;
    public Color endColor;
    public bool repeatColor = true;


	// Use this for initialization
	void Start ()
    {
        lighty = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update ()
    {    
        if(changeColors)
        {
            float BOOP = (Mathf.PingPong(Time.time, colorSpeed) / colorSpeed);
            lighty.color = Color.Lerp(startColor, endColor, BOOP);
        }
	}
}
