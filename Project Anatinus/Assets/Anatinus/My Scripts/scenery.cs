using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenery : MonoBehaviour
{
    public float speed = -8.0f;
    public float timer = 2.0f;
    public int endPoint = -30;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        //lock onto axises listed below
        Vector3 pos = transform.position;
        /*Y axis*/pos.y = transform.position.y;
        /*Z axis*/pos.z = transform.position.z;
        transform.position = pos;

        if (transform.position.x < endPoint)
        {
            Destroy(gameObject);
        }
    }
}


