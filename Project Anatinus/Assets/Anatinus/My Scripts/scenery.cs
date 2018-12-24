using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenery : MonoBehaviour
{
    public float speed = 10.0f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        if (transform.position.x > 10)
        { }

    }
}
