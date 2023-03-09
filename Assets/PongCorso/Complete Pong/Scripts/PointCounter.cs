using UnityEngine;

namespace CompletePong{

	public class PointCounter : MonoBehaviour{

		private int bounce = 0;

		private void OnCollisionEnter(Collision other){
			if (other.gameObject.name == "Ball"){
				bounce++;
				LevelManager.Instance.updateScoreUI(bounce);
			}
		}
	}
}