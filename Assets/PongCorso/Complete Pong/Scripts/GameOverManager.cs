using UnityEngine;

namespace CompletePong{

	public class GameOverManager : MonoBehaviour{

		private void OnCollisionEnter(Collision other){
			if (other.gameObject.name == "Ball"){
				gameOver();
			}
		}

		private void gameOver(){
			LevelManager.Instance.gameOver();
		}
	}
}