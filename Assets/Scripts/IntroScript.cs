using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

	public float buttonWidth = 100;
	public float buttonHeight = 30;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
				float offsetLeft = (Screen.width - buttonWidth) * 0.5f;
				float offsetTop = (Screen.height - buttonHeight) * 0.5f;
				if (GUI.Button (new Rect (offsetLeft, offsetTop, buttonWidth, buttonHeight), "play")) {
						Application.LoadLevel (1);
				}

	}

}
