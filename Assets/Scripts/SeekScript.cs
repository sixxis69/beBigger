using UnityEngine;
using System.Collections;

public class SeekScript : MonoBehaviour
{
		public GameObject targetGameObject;
		public float speed = 10f;
		public float SEEK_DISTANCE = 100f;

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
				
				if (distanceDetect < SEEK_DISTANCE) {
						Vector3 targetVelocity = Vector3.Normalize (targetGameObject.transform.position - transform.position);
						targetVelocity = targetVelocity * speed;
						targetVelocity = targetVelocity - rigidbody.velocity;	
						targetVelocity.y = 0;	
						rigidbody.AddForce (targetVelocity, ForceMode.VelocityChange);
						
						Vector3 lookAtPoint = targetGameObject.transform.position;
						lookAtPoint.y = transform.position.y;		
						rigidbody.transform.LookAt (lookAtPoint);
				}
		}

		void OnCollisionEnter (Collision hit)
		{
				if (hit.gameObject.CompareTag ("Player")) {
						Debug.Log ("player decrease point");
				}

		}
}
