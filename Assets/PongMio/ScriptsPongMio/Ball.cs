using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PongMio {

	public class Ball : MonoBehaviour {

		public Rigidbody rb;

		private TrailRenderer trail;
		public GameObject particleGoal;
		
		private float velocityMult = 10;
		public float maxVelocity = 30;
		public float actualSpeedX;
		public float actualSpeedY;

		private GameManager gameManager;
		//Girare palla nella direzione in cui sta andando!!

		private void Awake() {
			rb = GetComponent<Rigidbody>();
			trail = GetComponent<TrailRenderer>();
			particleGoal.SetActive(false);
		}

		public void LaunchBall() {
			float randomX = Random.Range(-50, -50);
			float randomZ = Random.Range(-100, 100);

			rb.AddForce(randomX, 0, randomZ );
		}

		public void Update() {
			actualSpeedX = Math.Abs(rb.velocity.x);
			actualSpeedY = Math.Abs(rb.velocity.x);
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
				rb.velocity *= 1f;
				velocityMult--;
			}
		}
	}

}

