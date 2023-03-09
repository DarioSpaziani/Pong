using UnityEngine;

namespace Delegati {

	public class ConsoleSubscriber : MonoBehaviour { //Da assegnare ad un gameObject (anche vuoto)
		private void Start() {
			ExampleDelegateManager.Instance.pressedSpaceBar += ShowMessage;
		}

		private void OnDestroy() {
			if (ExampleDelegateManager.Instance != null) {
				ExampleDelegateManager.Instance.pressedSpaceBar -= ShowMessage;
			}
		}

		private void ShowMessage() {
			print("mostrati!");
		}
	}

}