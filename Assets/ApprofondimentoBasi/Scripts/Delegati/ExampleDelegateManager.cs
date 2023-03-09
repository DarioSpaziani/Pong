using UnityEngine;

namespace Delegati {

	public class ExampleDelegateManager : Singleton<ExampleDelegateManager> {
		public delegate void PressedButton();

		public event PressedButton pressedSpaceBar;

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				if (pressedSpaceBar != null) {
					pressedSpaceBar();
				}
			}
		}
	}
}