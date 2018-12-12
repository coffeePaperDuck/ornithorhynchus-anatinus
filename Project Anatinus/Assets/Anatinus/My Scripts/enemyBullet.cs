using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{

    public float timer = 0.0f;
    public float speed;
    int tilt = 0;
    int rot = 0;
    public float pozition;
    public Material mat;
    private Light myLight;
    private Material bullG;


    




    // Use this for initialization
    void Start ()
    {


        var myLight = GameObject.FindWithTag("RHalo");





    }
	
	// Update is called once per frame
	void Update ()
    {





        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;


        if (timer > 3.0f)
        { timer = 0.0f; }


        timer += 1.0f * Time.deltaTime;
        if (timer > 0.0f)
        {

            Material mymat = GetComponent<Renderer>().material;
            mymat.SetColor("_EmissionColor", Color.red);



            myLight.enabled = false;
            


        }

        if (timer > 1.0f)
        {
          

        }


            if (timer > 2.0f)
        {
            Material mymat = GetComponent<Renderer>().material;
            mymat.SetColor("_EmissionColor", Color.yellow);

        }











    }













}
