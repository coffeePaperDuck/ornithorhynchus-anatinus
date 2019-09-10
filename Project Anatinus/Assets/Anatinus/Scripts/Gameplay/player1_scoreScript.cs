using UnityEngine;

namespace Anatinus.My_Scripts.Gameplay
{
    public class player1_scoreScript : MonoBehaviour
    {
        public GameObject player1Score;
        public static int scoreValue = 0000000;
        private GameObject _gameObjectPlayer1Score;

        // Start is called before the first frame update
        void Start()
        {
            _gameObjectPlayer1Score = GameObject.Find("player1Score");
        }

        // Update is called once per frame
        void Update()
        {
            player1Score = _gameObjectPlayer1Score;
            //player1_score.SimpleHelvetica.Text = "0000000" +scoreValue;
        }
    }
}
