using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PongMio {

	public class Ball : MonoBehaviour {

		private Rigidbody rb;
		private TrailRenderer trail;
		
		private float velocityMult = 10;
		public float maxVelocity = 30;

		private GameManager gameManager;

		private void Awake() {
			rb = GetComponent<Rigidbody>();
			trail = GetComponent<TrailRenderer>();
		}

		public void LaunchBall() {
			float randomX = Random.Range(-11, 11);
			float randomZ = Random.Range(-6, 6);

			rb.AddForce(randomX, 0, randomZ);
		}

		public void Update() {
			if (Math.Abs(rb.velocity.x) > maxVelocity || Mathf.Abs(rb.velocity.z) > maxVelocity) {
				trail.enabled = true;
			}
			else
				trail.enabled = false;
		}

		private void OnCollisionEnter(Collision other) {
			if (Mathf.Abs(rb.velocity.x) > maxVelocity || Mathf.Abs(rb.velocity.y) > maxVelocity) {
				velocityMult = 0;
			}
			else {
				velocityMult++;
			}

			if (velocityMult > 0) {
				rb.velocity *= 1.2f;
				velocityMult--;
			}
		}
	}

}

