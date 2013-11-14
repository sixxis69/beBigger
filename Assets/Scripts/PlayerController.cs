using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

		public Joystick joyStick;
		public Joystick touchPad;
		public float speed = 10.0f;
		public float gravity = 10.0f;
		public float maxVelocityChange = 10.0f;
		public bool isDebug = true;
		private Vector3 _lastDirection;

		void Awake ()
		{
				rigidbody.freezeRotation = true;
				rigidbody.useGravity = false;
		}

		void LateUpdate ()
		{
//						debugText.text = "count: " + touchPad.tapCount;
				//debugText.text = Input.GetAxis ("Vertical") + ":" + Input.GetAxis ("Horizontal");
		
				//				debugText.text = "joystick: " + joyStick.position.x + ":" + joyStick.position.y;
//
//				Vector3 newDirection;
//
//				if (isDebug) {
//					newDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
//				} else {
//					newDirection = new Vector3 (joyStick.position.x, 0f, joyStick.position.y);
//				}
//						
//				if (newDirection != _lastDirection && newDirection != Vector3.zero) {
//						_lastDirection = newDirection;
//						transform.rotation = Quaternion.LookRotation (_lastDirection);
//				}

				
		}

		void FixedUpdate ()
		{
//						Vector3 force;
//						if (isDebug) {
//								float v = Input.GetAxis ("Vertical");
//								float h = Input.GetAxis ("Horizontal");
//								force = new Vector3 (h, 0f, v);
//						} else {
//								force = new Vector3 (joyStick.position.x, 0f, joyStick.position.y);
//						}
//		
//						force = force * mulForce;
//						
//						AddDash ();
//					
//						rigidbody.AddForce (force);

				Vector3 targetVelocity;

				if (isDebug) {
						targetVelocity = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
				} else {
						targetVelocity = new Vector3 (joyStick.position.x, 0f, joyStick.position.y);
				}

				// Calculate how fast we should be moving
				targetVelocity = transform.TransformDirection (targetVelocity);
//				targetVelocity *= speed;
//
//				// Apply a force that attempts to reach our target velocity
//				Vector3 velocity = rigidbody.velocity;				
//				Vector3 velocityChange = (targetVelocity - velocity);
//				velocityChange.x = Mathf.Clamp (velocityChange.x, -maxVelocityChange, maxVelocityChange);
//				velocityChange.z = Mathf.Clamp (velocityChange.z, -maxVelocityChange, maxVelocityChange);
//				velocityChange.y = 0;
//
//				rigidbody.AddForce (velocityChange, ForceMode.VelocityChange);


				// We apply gravity manually for more tuning control
				rigidbody.AddForce (new Vector3 (0, -gravity * rigidbody.mass, 0));
		}

		void AddDash ()
		{
//				Vector3 force;
//
//				if (isDebug) {
//					
//				} else {
//						if (touchPad.isDash) {
//
//								force = _lastDirection * mulForce * 5.0f;
//								rigidbody.AddForce (force);
//						} else {
//								if (rigidbody.velocity.magnitude > maxSpeed) {
//										rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
//								}
//
//						}
//				}
		}
}
