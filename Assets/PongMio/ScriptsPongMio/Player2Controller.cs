using Unity.VisualScripting;
using UnityEngine;

namespace PongMio {

	[RequireComponent(typeof(Rigidbody))]
	public class Player2Controller : MonoBehaviour {
		
		public float speed;
		
		private Rigidbody rb;
		private float currentVelocity = 0;

		private void Awake() {
			rb = GetComponent<Rigidbody>();
			if (rb == null) {
				rb = this.AddComponent<Rigidbody>();
			}
			
			rb.useGravity = false;
			rb.isKinematic = true;
			
		}

		private void Update() {
			Movement();
			
		}

		private void Movement() {
			float vertical = 0;
			
			if (Input.GetKey(KeyCode.I)) {
				vertical++;
			}
			
			if (Input.GetKey(KeyCode.K)) {
				vertical--;
			}
			transform.position += new Vector3(0,0,vertical) * speed * Time.deltaTime;
		}

		private void OnCollisionEnter(Collision other) {
			if (other.gameObject.name == "Ball") {
				Rigidbody otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
				var vel = otherRigidbody.velocity;
				vel.y += currentVelocity / 2;
				otherRigidbody.velocity = vel;
			}
		}
	}
}

