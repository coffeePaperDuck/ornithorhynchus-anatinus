using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSolution : MonoBehaviour {

    public Light lighty;

    public bool changeColors = false;
    public float colorSpeed = 1.0f;
    public Color startColor;
    public Color endColor;
    public bool repeatColor = false;

    float startTime;


	// Use this for initialization
	void Start () {

        lighty = GetComponent<Light>();
        startTime = Time.time;



	}
	
	// Update is called once per frame
	void Update () {
	
        

        if(changeColors)
        {

            float t = (Mathf.Sin(Time.time - startTime * 20));
            lighty.color = Color.Lerp(startColor, endColor, t);


        }




	}
}
