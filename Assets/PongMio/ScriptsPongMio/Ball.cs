using UnityEngine;

namespace PongMio {

	public class Ball : MonoBehaviour {
    
		private Rigidbody rb;
		public float speedBall;
		private GameManager gameManager;
    
		private void Awake() {
			rb = GetComponent<Rigidbody>();
		}

		void Start()
		{
			rb.AddForce(transform.right * speedBall, ForceMode.Force);
		}
	}

}

