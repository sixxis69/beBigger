using UnityEngine;
using System.Collections;

public class FleeScript : MonoBehaviour
{
		public GameObject targetGameObject;
		public float speed = 4f;
		public float FLEE_DISTANCE = 50f;

		// Use this for initialization
		void Start ()
		{
				rigidbody.freezeRotation = true;

				if (!targetGameObject) {
						targetGameObject = GameObject.FindGameObjectWithTag ("Player");
				}
		}

		void FixedUpdate ()
		{
				Vector3 source = transform.position;
				Vector3 target = targetGameObject.transform.position;

				float distanceDetect = Vector3.Distance (source, target);
				
				if (distanceDetect < FLEE_DISTANCE) {
						Vector3 targetDirection = Vector3.Normalize (transform.position - targetGameObject.transform.position);
						targetDirection.y = 0;
						rigidbody.MovePosition (rigidbody.position + targetDirection * Time.deltaTime * speed);
				}
		}

		void OnCollisionEnter (Collision hit)
		{
				if (hit.gameObject.CompareTag("Player")){
						Destroy (gameObject);
				}

		}
}
