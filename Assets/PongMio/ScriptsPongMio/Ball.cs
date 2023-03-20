using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PongMio {

	public class Ball : MonoBehaviour {

		private Rigidbody rb;
		private TrailRenderer trail;
		public GameObject particleGoal;
		
		public float velocityMult = 10;
		public float maxVelocity = 30;
		

		private GameManager gameManager;

		private void Awake() {
			rb = GetComponent<Rigidbody>();
			trail = GetComponent<TrailRenderer>();
			particleGoal.SetActive(false);
		}

		public void LaunchBall() {
			float randomX = Random.Range(-50, -50);
			float randomZ = Random.Range(-100, 100);

			rb.AddForce(randomX, 0, randomZ);
		}

		public void Update() {
			if (Math.Abs(rb.velocity.x) > maxVelocity || Mathf.Abs(rb.velocity.z) > maxVelocity) {
				trail.enabled = true;
			}
			else
				trail.enabled = false;

			Vector3 movementDir = new Vector3(rb.velocity.x, 0, rb.velocity.z);

			if (movementDir != Vector3.zero) {
				transform.forward = movementDir;
			}
			
			Debug.Log(rb.velocity.x);
		}

		private void OnCollisionEnter(Collision other) {
			if (Mathf.Abs(rb.velocity.x) > maxVelocity || Mathf.Abs(rb.velocity.y) > maxVelocity) {
				velocityMult = 0;
			}
			else {
				velocityMult++;
			}

			if (velocityMult > 0) {
				rb.velocity *= 1.01f;
				velocityMult--;
			}
		}
	}

}

