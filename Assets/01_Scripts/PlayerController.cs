using Unity.VisualScripting;
using UnityEngine;

namespace PongMio {

	[RequireComponent(typeof(Rigidbody))]
	public class PlayerController : Player 
	{
		
		private void FixedUpdate() 
		{
			Movement();			
		}

		private void Movement() {
			float vertical = Input.GetAxis("Vertical");

			Vector3 dir = new Vector3(0, 0, vertical);

            if (Input.GetKey(KeyCode.W)) {
				rb.velocity = dir * speed;
            }
			if (Input.GetKey(KeyCode.S)) {
				rb.velocity = dir * speed;
            }
		}
	}
}

