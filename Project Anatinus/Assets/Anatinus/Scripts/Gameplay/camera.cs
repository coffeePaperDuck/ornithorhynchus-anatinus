using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectPlayer;

    // Update is called once per frame
    void Update()
    {
        if (_gameObjectPlayer.transform.position.y < 7.2f && _gameObjectPlayer.transform.position.y > -7.2f) //if player is within these coordinates...
        {
            transform.localPosition = new Vector3(0, _gameObjectPlayer.transform.position.y / 4, -10); //...then follow the player's position divided by 4
        }
    }
}