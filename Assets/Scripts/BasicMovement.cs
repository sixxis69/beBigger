using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour
{
		public bool isDebug = true;
		public Joystick joyStick;
		public Joystick touchPad;
		public float walkSpeed = 9.5f;
		public float dashSpeed = 100f;
		public float dashTime = 0.10f;
		public float delayDash = 2f;
		public bool isDash;
		private float _currentDelay;
		private float _currentTime;

		void Start ()
		{
				_currentDelay = -delayDash;
				_currentTime = 0f;
		}

		Vector3 getUserInput ()
		{
				Vector3 userInput = Vector3.zero;


				if (isDebug) {
						userInput = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
				} else {
						userInput = new Vector3 (joyStick.position.x, 0f, joyStick.position.y);
				}

				userInput = Camera.main.transform.TransformDirection (userInput);
				userInput.y = 0;
				userInput.Normalize ();

				return userInput;
		}

		void LateUpdate ()
		{
				Vector3 newDirection = getUserInput ();

				// NOTE: fixed stay  rotation
				if (Input.anyKey && newDirection != Vector3.zero) {
						transform.rotation = Quaternion.LookRotation (newDirection);
				}
		}

		void FixedUpdate ()
		{
				// NOTE: dash
				if (_currentDelay + delayDash < Time.time) {
						isDash = true;
				} else {
						isDash = false;
				}


				if (isDash) {
						if (Input.GetKey (KeyCode.Space)) {
								addDash ();
						} else if (touchPad.isDash) {
								addDash ();
						}	
				}

				// NOTE: user control
				Vector3 targetVelocity = getUserInput ();	
				if (Time.time > _currentTime + dashTime) {
					
						if (Input.anyKey) {
								targetVelocity = Vector3.Normalize (targetVelocity);
								targetVelocity *= walkSpeed;

								targetVelocity = targetVelocity - rigidbody.velocity;
								targetVelocity.y = 0;

								rigidbody.AddForce (targetVelocity, ForceMode.VelocityChange);
						} else {
								rigidbody.AddForce (-rigidbody.velocity, ForceMode.VelocityChange);
						}

						
				}	
		}

		void addDash ()
		{
				_currentDelay = Time.time;
				_currentTime = Time.time;

				rigidbody.AddRelativeForce (dashSpeed * Vector3.forward, ForceMode.VelocityChange);
		}
}
