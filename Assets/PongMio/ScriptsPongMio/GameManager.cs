using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PongMio {

	public class GameManager : Singleton<GameManager> {

		private static GameManager Instance;

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
		private int scorePlayer1;
		private int scorePlayer2;

		private void Awake() {
			if (Instance == null)
				Instance = this;

			else if (Instance != this)
				Destroy(gameObject);
			
			pointPlayerSub = FindObjectOfType<PointPlayerSub>();
			pointPlayer2Sub = FindObjectOfType<PointPlayer2Sub>();
			
		}

		private void Start() {
			Time.timeScale = 1;
			StartCoroutine(CountDownStart());

		}

		private IEnumerator CountDownStart() {
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

		public void ScorePlayer1Func(int point1) {
			scorePlayer1Text.text = ("Player 1: " + point1);
		}
		
		public void ScorePlayer2Func(int point2) {
			scorePlayer2Text.text = ("Player 2: " + point2);
		}

		public void endMatch() 
		{
			if (pointPlayerSub.point1 >= 3) {
				winnerPanel.SetActive(true);
				winnerText.text = "Player 1 Win!";
				winnerText.color = Color.blue;
			}
			if (pointPlayer2Sub.point2 >= 3) {
				winnerPanel.SetActive(true);
				winnerText.text = "Player 2 Win!";
				winnerText.color = Color.red;
			}
			//aggiunger ciclo di colori per la scritta game over
			finalScoreText.text = pointPlayerSub.point1 + " - " + pointPlayer2Sub.point2;

		}

		private IEnumerator CountdownRematch() {
			var countdown = 3;

			for (int i = 3; i > 0; i--) {
				countdown--;
				Debug.Log(countdown);
				yield  return new WaitForSeconds(1f);
			}
			rematchPanel.SetActive(true);
			scorePanel.SetActive(false);
			winnerPanel.SetActive(false);
		}

		public void Rematch() {
			StopCoroutine(CountdownRematch());
			SceneManager.LoadScene(0);
		}
	}

}