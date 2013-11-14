using UnityEngine;
using System.Collections;

public class TargetCamera : MonoBehaviour
{
		public Transform target;
		private Vector3 _offset;
		// Use this for initialization
		void Start ()
		{
				_offset = target.position - this.transform.position;
				this.transform.LookAt (target);
		}
		// Update is called once per frame
		void Update ()
		{
				Vector3 targetPos = target.position - _offset;

				this.transform.position = Vector3.Lerp (this.transform.position, targetPos, Time.deltaTime * 5);
				
				
		}
}
