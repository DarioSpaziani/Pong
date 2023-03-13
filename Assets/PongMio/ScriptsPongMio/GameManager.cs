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
			
			winnerPanel.SetActive(false);
			rematchPanel.SetActive(false);
		}

		private void Start() {
			Time.timeScale = 1;
		}

		private void Update() {
			EndMatch();
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

		private void EndMatch() 
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
			
			
			yield return null;
		}

		public void Rematch() {
			SceneManager.LoadScene(0);
		}
	}

}