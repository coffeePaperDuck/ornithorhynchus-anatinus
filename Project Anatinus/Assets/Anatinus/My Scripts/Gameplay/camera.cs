using UnityEngine;

namespace Anatinus.My_Scripts.Gameplay
{
    public class camera: MonoBehaviour
    {
        //public float y;
        public Transform player;
        private GameObject _gameObjectPlayer;

        // Start is called before the first frame update
        void Start()
        {
            _gameObjectPlayer = GameObject.Find("player");
        }

        // Update is called once per frame
        void Update()
        {
            transform.localPosition = new Vector3(0, _gameObjectPlayer.transform.position.y/4, -10);
        }
    }
}
