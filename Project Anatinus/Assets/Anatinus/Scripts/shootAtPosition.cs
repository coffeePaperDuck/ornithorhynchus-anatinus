using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootAtPosition : MonoBehaviour
{
  

    float speed = 2f;

    GameObject _target;

    Rigidbody _rb;

    Vector3 _moveDirection;



    void Start()
    {
        _rb = GetComponent<Rigidbody> ();
        _target = GameObject.Find ("player");
        _moveDirection = (_target.transform.position - transform.position).normalized * speed;
        _rb.velocity = new Vector3(_moveDirection.x, _moveDirection.y, _moveDirection.z);
    }
}
    