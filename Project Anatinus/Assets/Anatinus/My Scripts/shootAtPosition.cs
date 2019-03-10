using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootAtPosition : MonoBehaviour
{
  

    float speed = 2f;

    GameObject target;

    Rigidbody rb;

    Vector3 moveDirection;



    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        target = GameObject.Find ("Player(Clone)");
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);



    }

    // Update is called once per frame
    void Update()
    {






    }





}
    