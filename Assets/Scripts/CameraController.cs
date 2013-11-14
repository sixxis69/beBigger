using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float speed = 10f;
	private Vector3 _offset;

	// Use this for initialization
	void Start () {
				_offset = target.position - this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
//				transform.position = target.position - _offset;
				Vector3 targetPos = target.position - _offset;
				this.transform.position = Vector3.Lerp (this.transform.position, targetPos, 10f*Time.deltaTime*speed);
	}
}
