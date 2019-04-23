using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class enemyHammerhead : MonoBehaviour
{
    public Transform missileLauncher1;
    public Transform missileLauncher2;
    public GameObject missile;

    public float timer;
    public float timerSpeed = 1;
    public float timerMax = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += timerSpeed * Time.deltaTime;
        if (timer > timerMax)
        {
            LeanPool.Spawn(missile, missileLauncher1.position, missileLauncher1.rotation);
            LeanPool.Spawn(missile, missileLauncher2.position, missileLauncher2.rotation);
            timer = 0;
        }
    }
}
