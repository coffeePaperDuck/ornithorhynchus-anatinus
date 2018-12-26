using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatLighter : MonoBehaviour {

    //private Light eatLight;
    private MeshFilter meshTest;
    
    

    // Use this for initialization
    void Start () {

        //eatLight = GetComponent<Light>();
        meshTest = GetComponent<MeshFilter>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.G))
        {

            //eatLight.enabled = !eatLight.enabled;


            

        }

    
    }
}
