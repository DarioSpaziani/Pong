using Unity.VisualScripting;
using UnityEngine;

namespace PongMio {

	[RequireComponent(typeof(Rigidbody))]
	public class PlayerController : MonoBehaviour {
		public float speed;
		private Rigidbody rb;
		private float currentVelocity = 5;
		private Vector3 previousPosition;

		private void Awake() {
			rb = GetComponent<Rigidbody>();
			if (rb == null) {
				this.AddComponent<Rigidbody>();
			}
			rb.useGravity = false;
		}

		private void Update() {
			Movement();
			var position = transform.position;
			currentVelocity = ((position - previousPosition).magnitude) / Time.deltaTime;
			previousPosition = position;
		}

		private void Movement() {
			float verticalInput = Input.GetAxis("Vertical") * Time.deltaTime;

			Vector3 movement = new Vector3(0.0f, 0.0f , verticalInput);

			transform.Translate(movement * speed);
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

