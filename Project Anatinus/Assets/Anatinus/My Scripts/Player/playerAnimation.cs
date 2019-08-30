using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    [SerializeField] private float _animTime = 0.25f; //time for ship tilting
    [SerializeField] private float _timeSpeed = 1; //time speed
    int _tilt = 0; //is applied to X rotation, makes it look like the ship is tilting when moving (via "ship animation tilts" code below)

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    // Update is called once per frame
    void Update()
    {
        //Essentials

        var dt = Time.deltaTime; //delta time


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //ship animation tilt states

        if (_animTime > 0.0f && _animTime < 0.1f)
        { _tilt = -30; } //tilted down x2

        if (_animTime > 0.1f && _animTime < 0.2f)
        { _tilt = -15; } //tilted down x1

        if (_animTime > 0.2f && _animTime < 0.3f)
        { _tilt = 0; } //default state

        if (_animTime > 0.3f && _animTime < 0.4f)
        { _tilt = 15; } //tilted up x1

        if (_animTime > 0.4f && _animTime < 0.5f)
        { _tilt = 30; } //tilted up x2


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //inputs for animation

        if (Input.GetAxisRaw("Vertical") > 0 && _animTime < 0.5f) //if input = up, and ship is not tilted all the way up...
        { _animTime += _timeSpeed * dt; } //...then tilt ship up


        if (Input.GetAxisRaw("Vertical") == 0 && _animTime > 0.3f) //if there is no input, and ship is tilted up...
        { _animTime -= _timeSpeed * dt; } //...then tilt ship back down


        if (Input.GetAxisRaw("Vertical") < 0 && _animTime > 0) //if input = down, and ship is not tilted all the way down...
        { _animTime -= _timeSpeed * dt; } //...then tilt ship down


        if (Input.GetAxisRaw("Vertical") == 0 && _animTime < 0.2f) //if there is no input, and ship is tilted down...
        { _animTime += _timeSpeed * dt; } //...then tilt ship back up


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //apply tilt animation
        transform.eulerAngles = new Vector3(_tilt, 0, 0); //tilt the x-axis
    }
}
