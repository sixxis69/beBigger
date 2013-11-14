using UnityEngine;
using System.Collections;

public class WinScore : MonoBehaviour {

	public float buttonWidth = 100;
	public float buttonHeight = 30;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI(){


		float offsetLeft = (Screen.width - buttonWidth) * 0.5f;
		float offsetTop = (Screen.height - buttonHeight) * 0.5f;

				GUI.Label (new Rect (offsetLeft, offsetTop - 50, buttonWidth, buttonHeight), "==== WIN ====");
				


		if (GUI.Button (new Rect (offsetLeft, offsetTop, buttonWidth, buttonHeight), "play again")) {
			Application.LoadLevel (1);
		}



	}
}
