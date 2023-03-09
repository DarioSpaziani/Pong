using UnityEngine;

namespace PongMio {

	public class GameManager : Singleton<GameManager> {
    
		public delegate void EndGame();

		public event EndGame gameOverText;

		private void OnCollisionEnter(Collision collision) { // è la palla che si deve iscrivere
			if (collision.gameObject.CompareTag("WallEnd")) 
				gameOverText?.Invoke();
		}
    
	}

}

