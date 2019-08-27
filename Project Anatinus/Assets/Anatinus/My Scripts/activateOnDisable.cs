using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateOnDisable : MonoBehaviour
{
    public GameObject activatable;

    //this is so that when the game starts, it does not activate as soon as the objects with this script load into the level
    public bool eligible = false;

    // Start is called before the first frame update
    void Start()
    {
        eligible = true;
    }

    // Update is called once per frame
    void Update()
    {

        activatable.transform.position = this.transform.position;
    }

    void OnDisable()
    {
        if (eligible == true)
        {
            activatable.SetActive(true);
        }
    }
}
