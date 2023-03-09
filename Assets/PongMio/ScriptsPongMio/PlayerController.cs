using UnityEngine;

namespace PongMio {

	public class PlayerController : MonoBehaviour {
		public float speed;

		private void Update() {
			Movement();
		}

		private void Movement() {
			float vertical = 0;

			if (Input.GetKey(KeyCode.W)) {
				vertical++;
			}
        
			if (Input.GetKey(KeyCode.S)) {
				vertical--;
			}

			transform.position += new Vector3(0,0 , vertical) * speed * Time.deltaTime;
		}
	}

}

