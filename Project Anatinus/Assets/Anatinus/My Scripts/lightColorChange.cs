using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightColorChange : MonoBehaviour
{
    public Light lightComponent;

    public bool changeColors = true;
    public float colorSpeed = 1.0f;
    public Color startColor;
    public Color endColor;
    public bool repeatColor = true;


	// Use this for initialization
	void Start ()
    {
        lightComponent = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update ()
    {    
        if(changeColors)
        {
            float lightChangeColor = (Mathf.PingPong(Time.time, colorSpeed) / colorSpeed);
            lightComponent.color = Color.Lerp(startColor, endColor, lightChangeColor);
        }
	}
}
