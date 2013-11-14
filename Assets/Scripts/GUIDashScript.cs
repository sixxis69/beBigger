using UnityEngine;
using System.Collections;

public class GUIDashScript : MonoBehaviour
{
		private BasicMovement _basicMovement;
		public Texture2D activeTexture;
		public Texture2D deactiveTexture;
		// Use this for initialization
		void Start ()
		{
				_basicMovement = GameObject.FindGameObjectWithTag ("Player").GetComponent<BasicMovement> ();
		}
		// Update is called once per frame
		void Update ()
		{
		
		}

		void OnGUI ()
		{

				if (_basicMovement.isDash)
						guiTexture.texture = activeTexture;
				else
						guiTexture.texture = deactiveTexture;
		}
}
