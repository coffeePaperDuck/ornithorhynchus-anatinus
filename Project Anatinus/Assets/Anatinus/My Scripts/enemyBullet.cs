using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class enemyBullet : NetworkBehaviour
{

    public float timer = 0.0f;
    public float speed;
    public Material mat;

    Color lerpedColor = Color.red;





    // Use this for initialization
    void Start ()
    {





    }
	
	// Update is called once per frame
	void Update ()
    {




        lerpedColor = Color.Lerp(Color.red, Color.yellow, Mathf.PingPong(Time.time, 1));
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;


        if (timer > 3.0f)
        { timer = 0.0f; }


        timer += 1.0f * Time.deltaTime;
        if (timer > 0.0f)
        {

            Material mymat = GetComponent<Renderer>().material;
            mymat.SetColor("_EmissionColor", lerpedColor);



        }

        //if (timer > 1.0f)
        //{


        //}


        if (timer > 2.0f)
        {
            Material mymat = GetComponent<Renderer>().material;
            mymat.SetColor("_EmissionColor", lerpedColor);

        }

    }
}
