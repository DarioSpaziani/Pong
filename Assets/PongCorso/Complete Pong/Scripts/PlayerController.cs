using UnityEngine;

namespace CompletePong{

	public class PlayerController : MonoBehaviour{

		public float speed;

		private Rigidbody rb;
		private Vector2 dimension;
		private Vector3 previousPosition;
		private float currentVelocity = 0;

		private void Start(){
			rb = GetComponent<Rigidbody>();
			if (rb == null)
				rb = gameObject.AddComponent<Rigidbody>();
			rb.useGravity = false;
			rb.isKinematic = true;

			dimension.x = transform.localScale.x;
			dimension.y = transform.localScale.y;

			previousPosition = transform.position;
		}

		private void Update(){
			float verticalInput = Input.GetAxis("Vertical") * Time.deltaTime;

			Vector3 movement = new Vector3(0.0f, verticalInput, 0.0f);

			transform.Translate(movement * speed);

			transform.position = new Vector3(
				transform.position.x,
				Mathf.Clamp(transform.position.y, Camera.main.OrthographicBounds().min.y + dimension.y / 2,
					Camera.main.OrthographicBounds().max.y - dimension.y / 2),
				0
			);

			currentVelocity = ((transform.position - previousPosition).magnitude) / Time.deltaTime;
			previousPosition = transform.position;

			//sign correction
			currentVelocity = Mathf.Sign(verticalInput) * currentVelocity;
		}

		private void OnCollisionExit(Collision other){
			if (other.gameObject.name == "Ball"){
				Rigidbody otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
				var vel = otherRigidbody.velocity;
				vel.y += currentVelocity / 2;
				otherRigidbody.velocity = vel;
			}
		}
	}
}
