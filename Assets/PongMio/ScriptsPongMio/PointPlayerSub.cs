using UnityEngine;
using UnityEngine.SceneManagement;

namespace PongMio {
	public class PointPlayerSub : MonoBehaviour {
		
		public int point1;
		private Ball ball;
		
		private void Start() {
			ball = FindObjectOfType<Ball>();
		}

		private void OnCollisionEnter(Collision collision) {
			if (collision.gameObject.name == "Ball") {
				point1++;
				GameManager.Instance.ScorePlayer1Func(point1);
				SceneManager.LoadScene(0);
			}
		}
	}
}

