using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PongMio {

	public class GameManager : Singleton<GameManager> {

		private static GameManager instance;

		[Header("Panels")]
		public GameObject scorePanel;
		public GameObject winnerPanel;
		public GameObject rematchPanel;
		
		[Header("Texts")]
		public TextMeshProUGUI finalScoreText;
		public TextMeshProUGUI winnerText;
		public TextMeshProUGUI scorePlayer1Text;
		public TextMeshProUGUI scorePlayer2Text;
		public TextMeshProUGUI countStartText;
		
		[Header("Variables")]
		public Ball ball;
		public PointPlayerSub pointPlayerSub;
		public PointPlayer2Sub pointPlayer2Sub;
		public float timer;

		public override void Awake() {
			base.Awake();
			
			pointPlayerSub = FindObjectOfType<PointPlayerSub>();
			pointPlayer2Sub = FindObjectOfType<PointPlayer2Sub>();
			
		}

		private void Start() {
			winnerPanel.SetActive(false);
			StartCoroutine(CountDownStart());

		}

        private void Update()
        {
            if (pointPlayerSub.point1 >= 3)
            {
                winnerPanel.SetActive(true);
                winnerText.text = "Player 1 Win!";
                winnerText.color = Color.blue;
				endMatch();
            }
			if (pointPlayer2Sub.point2 >= 3)
			{
				winnerPanel.SetActive(true);
				winnerText.text = "Player 2 Win!";
				winnerText.color = Color.red;
				endMatch();
			}
        }
        public void ScorePlayer1Func(int point1)
        {
            scorePlayer1Text.text = ("Player 1: " + point1);
        }

        public void ScorePlayer2Func(int point2)
        {
            scorePlayer2Text.text = ("Player 2: " + point2);
        }

        private IEnumerator CountDownStart() 
		{
			for (int i = 3; i > 0; i--) {
				countStartText.text = i.ToString();
				yield return new WaitForSeconds(1f);
			}

			countStartText.text = "START!";
			yield return new WaitForSeconds(1f);
			
			scorePanel.SetActive(true);
			winnerPanel.SetActive(false);
			rematchPanel.SetActive(false);
			countStartText.enabled = false;
			
			Launch();
		}
		

		private void Launch() {
			ball.LaunchBall();
		}

		public void endMatch() 
		{
			//aggiunger ciclo di colori per la scritta game over
			finalScoreText.text = pointPlayerSub.point1 + " - " + pointPlayer2Sub.point2;
			
			ball.rb.velocity = Vector3.zero;
			timer += Time.time;
			if(timer > 3)
			{
                rematchPanel.SetActive(true);
			}
		}

		private IEnumerator CountdownStartMatch() {
			var countdown = 3;

			for (int i = 3; i > 0; i--) {
				countdown--;
				yield  return new WaitForSeconds(1f);
			}
			rematchPanel.SetActive(true);
			scorePanel.SetActive(false);
			winnerPanel.SetActive(false);
		}

		public void Rematch()
		{
			StopCoroutine(CountdownStartMatch());
			SceneManager.LoadScene(0);
		}
	}

}