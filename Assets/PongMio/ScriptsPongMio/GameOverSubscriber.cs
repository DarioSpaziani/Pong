using TMPro;
using UnityEngine;

namespace PongMio {
	public class GameOverSubscriber : MonoBehaviour {
		public TextMeshProUGUI endText;
    
		private void Start() {
			endText.enabled = false;
			if (GameManager.Instance != null) {
				GameManager.Instance.gameOverText += ShowText;
			}
		}

		private void OnDestroy() {
			if (GameManager.Instance != null) GameManager.Instance.gameOverText -= ShowText;
		}

		private void ShowText() {
			if (endText != null) {
				endText.enabled = true;
			}
			Debug.Log("ciao");
		}
	}
    

}
