using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour
{
    public float maxSpeedX = 5f;
    public float maxSpeedY = 100f;
    public float speed = 10f;
    public bool jumpable = true;
    public bool grounded = false;
    public bool squashed = false;

    public GameObject parent;
    Rigidbody rbX;
    Rigidbody rbY;
    Vector3 originalScale;
    Vector3 squashedScale;
    Vector3 squishedScale;

    private Quaternion _targetRotation = Quaternion.identity;

    public void SetBlendedEulerAngles(Vector3 angles)
    {
        _targetRotation = Quaternion.Euler(0,0,0);
    }

    // Start is called before the first frame update
    void Start()
    {
        rbX = GetComponent<Rigidbody>();
        rbY = GetComponent<Rigidbody>();

        originalScale = new Vector3(1f, 1f, 1f);
        squashedScale = new Vector3(1.75f, 0.25f, 1.75f);
        squishedScale = new Vector3(0.25f, 1.75f, 0.25f);
    }

    /*void FixedUpdate()
    {
        if (rbX.velocity.magnitude > maxSpeedX)
        {
            rbX.velocity = rbX.velocity.normalized * maxSpeedX;
        }

        if (rbY.velocity.magnitude > maxSpeedY)
        {
            rbY.velocity = rbY.velocity.normalized * maxSpeedY;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        if (jumpable == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            //parent.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Move up
        if (Input.GetKey(KeyCode.UpArrow) && jumpable == true)
        {
            rbY.AddForce(new Vector3(0, 75, 0), ForceMode.Impulse);
            jumpable = false;
            transform.localScale = Vector3.Lerp(transform.localScale, squishedScale, 100 * Time.deltaTime);

            transform.rotation = Quaternion.Euler(0, 0, 0);
            //parent.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, 1 * Time.deltaTime);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.Translate(1, 1, 1);
            rbX.AddForce(new Vector3(-1, 0, 0), ForceMode.Impulse);
            //rb.AddForce(-Vector3.right * speed);
            //transform.Translate(-speed * Time.deltaTime, 0, 0);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Move down
        if (Input.GetKey(KeyCode.DownArrow))
        {

            rbY.AddForce(new Vector3(0, -50, 0), ForceMode.Impulse);
            if (jumpable == false)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                parent.transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.localScale = Vector3.Lerp(transform.localScale, squishedScale, speed * Time.deltaTime);
            }
            else
            {
                transform.localScale = Vector3.Lerp(transform.localScale, squashedScale, speed * Time.deltaTime);

                //lock onto axises listed below
                Quaternion rot = transform.rotation;
                //Z axis
                rot.x = 0;
                rot.y = 0;
                rot.z = 0;
                transform.rotation = rot;

                if (squashed == false)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    parent.transform.rotation = Quaternion.Euler(0, 0, 0);
                    //transform.position += new Vector3(0, -0.1f, 0);
                    squashed = true;
                }
            }
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, speed * Time.deltaTime);
            squashed = false;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rbX.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
            //rb.AddForce(Vector3.right * speed);
            //transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
    //Collisions
    void OnCollisionEnter(Collision collision)
    {
        grounded = true;
        jumpable = true;
    }

}
