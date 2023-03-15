using UnityEngine;

namespace PongMio {
	public class PointPlayer2Sub : MonoBehaviour {
		public int point2;
		public Ball ball;

		private void Start() {
			ball = FindObjectOfType<Ball>();
		}

		private void OnCollisionEnter(Collision collision) {
			if (collision.gameObject.name == "Ball") {
				point2++;
				GameManager.Instance.ScorePlayer2Func(point2);
				//ball.particleGoal.SetActive(true);
			}
		}
	}
}