using UnityEngine;

namespace PongMio {
	public class PointPlayerSub : MonoBehaviour {
		
		public int point1;
		
		private void OnCollisionEnter(Collision collision) {
			if (collision.gameObject.name == "Ball") {
				point1++;
				GameManager.Instance.ScorePlayer1Func(point1);
			}
		}
	}
}

