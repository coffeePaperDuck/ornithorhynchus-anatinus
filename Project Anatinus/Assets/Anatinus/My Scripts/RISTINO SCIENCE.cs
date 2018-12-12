using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class RISTINOSCIENCE : NetworkBehaviour
{
    public float speed = 10.0f;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        float horz = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float vert = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        transform.Translate(horz, vert, 0);









    }
}


