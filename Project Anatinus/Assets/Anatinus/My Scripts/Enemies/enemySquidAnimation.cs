using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySquidAnimation : MonoBehaviour
{
    public float timer = 0.0f;
    public float speed = 8.0f;
    float rot = 0.0f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.eulerAngles = new Vector3(0, -rot, 0);

        timer += speed * Time.deltaTime;
        if (timer > 1.0f)
        {
            rot += 22.5f;
            timer = 0.0f;
        }
    }
}
