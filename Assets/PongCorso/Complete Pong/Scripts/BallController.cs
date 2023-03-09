using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CompletePong{

	public class BallController : MonoBehaviour{

		private Rigidbody rb;
		private TrailRenderer trail;

		private int velocityMult = 10;
		private int maxVelocity = 30;

		void Start(){
			rb = GetComponent<Rigidbody>();
			trail = GetComponent<TrailRenderer>();
		}

		public void launchBall(){
			float randomX = Random.Range(-800, -300);
			float randomY = Random.Range(-1000, 1000);

			rb.AddForce(randomX, randomY, 0);
		}

		void Update(){
			if (Math.Abs(rb.velocity.x) > maxVelocity || Math.Abs(rb.velocity.y) > maxVelocity){
				trail.enabled = true;
			} else{
				trail.enabled = false;
			}

			transform.position = new Vector3(
				Mathf.Clamp(transform.position.x, Camera.main.OrthographicBounds().min.x, Camera.main.OrthographicBounds().max.x),
				Mathf.Clamp(transform.position.y, Camera.main.OrthographicBounds().min.y, Camera.main.OrthographicBounds().max.y),
				0
			);
		}

		private void OnCollisionEnter(Collision other){
			if (Math.Abs(rb.velocity.x) > maxVelocity || Math.Abs(rb.velocity.y) > maxVelocity){
				velocityMult = 0;
			} else{
				velocityMult++;
			}

			if (velocityMult > 0){
				rb.velocity = rb.velocity * 1.2f;
				velocityMult--;
			}
		}
	}
}