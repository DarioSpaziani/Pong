using UnityEngine;

namespace CompletePong{

	public class StartController : MonoBehaviour{

		void Start(){
			LevelManager.Instance.startGame();
		}

	}
}