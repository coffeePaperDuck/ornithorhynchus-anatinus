using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloon : MonoBehaviour
{
    public GameObject balloonPrefab;
    public GameObject packagePrefab;

    public float speed = 1;

    private GameObject _gameObjectBalloonExists;
    private GameObject _gameObjectPackageExists;

    // Start is called before the first frame update
    void Start()
    {
        _gameObjectPackageExists = GameObject.Find("packagePrefab");
        _gameObjectBalloonExists = GameObject.Find("balloonPrefab");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        balloonPrefab.name = "balloonPrefab";
        packagePrefab.name = "packagePrefab";

        //If balloon is missing, then fall like a lead mountain
        if (!_gameObjectBalloonExists)
        {
            speed -= 50 * Time.deltaTime;
        }

        //If package is missing, then rise like a balloon...go figure
        if (!_gameObjectPackageExists)
        {
            speed += 5 * Time.deltaTime;
        }

        //If both still exist, keep rising.
        if (_gameObjectBalloonExists && _gameObjectBalloonExists)
        {
            speed += 1 * Time.deltaTime;
        }
    }
}
