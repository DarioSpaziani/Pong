using UnityEngine;
using UnityEngine.SceneManagement;

namespace PongMio {
	public class PointPlayer2Sub : MonoBehaviour 
	{
		public int point2;
		
		private void OnCollisionEnter(Collision collision) {
			if (collision.gameObject.name == "Ball") {
				point2++;
				GameManager.Instance.ScorePlayer2Func(point2);
				SceneManager.LoadScene(0);
			}
		}
	}
}