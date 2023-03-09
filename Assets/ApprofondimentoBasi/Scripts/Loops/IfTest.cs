using UnityEngine;

namespace LezioneBasi 
{
	public class IfTest : MonoBehaviour {
		public bool choice = false;
		public int switchCase = 0;
		void Update() {
			UseIf();
			UseSwitch();

		}

		private void UseIf() {
			if (choice) {
				print("choice è vera");
			}
			else {
				print("choice è falsa");
			}
		}

		private void UseSwitch() {
			switch (switchCase) {
				case 0:
					print("0");
					break;
				case 1:
					print("1");
					break;
				case 2:
					print("2");
					break;
				default:
					print("caso di default");
					break;
			}
		}
	}
}