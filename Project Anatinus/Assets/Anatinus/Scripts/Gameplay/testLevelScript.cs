using System.Collections.Generic;
using UnityEngine;

namespace Anatinus.My_Scripts.Gameplay
{
    public class testLevelScript : MonoBehaviour
    {
        public float timer;
        public float timerSpeed = 1;

        public int timesIndex = 0;

        [SerializeField]
        public List<GameObject> enemies;

        [SerializeField]
        public List<float> times;

        public List<int> pauseAtIndex;

        int _spawnPointY;

        // public List<string> Enemies;


        // Update is called once per frame
        void Update()
        {
            _spawnPointY = Random.Range(-4, 4);
            Vector3 spawnPosition = new Vector3(15, _spawnPointY, 0);

            timer += timerSpeed * Time.deltaTime;

            //Spawn enemies according to the times set on the level script in the Unity Inspector.//
            if (timer > times[timesIndex])
            {
                enemies[timesIndex].transform.position = spawnPosition;
                timesIndex += 1;
            }

        }
    }
}