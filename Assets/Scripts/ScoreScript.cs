using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour
{
		public GameObject prefab;
		public GUIText guiScore;
		public int currentScore;
		public int totalScore;
		// Use this for initialization
		void Start ()
		{
				ResetScore ();
		}

		void ResetScore ()
		{
				currentScore = 0;
				totalScore = GameObject.FindGameObjectsWithTag ("small").Length;
		}
		// Update is called once per frame
		void Update ()
		{
				guiScore.text = currentScore + "/" + totalScore;
		}

		void OnCollisionEnter (Collision hit)
		{
				if (hit.gameObject.tag == "small") {
						currentScore++;
						
						ContactPoint contact = hit.contacts [0];
						Quaternion rot = Quaternion.FromToRotation (Vector3.up, contact.normal);
						Vector3 pos = contact.point;
						
						GameObject particle = Instantiate (prefab, pos, rot) as GameObject;
						Destroy (particle, 1f);
						
				}

				if (hit.gameObject.tag == "big") {
						
						if (currentScore < totalScore) {
								Application.LoadLevel (0);
						} else {
								Application.LoadLevel (2);
						}
						
				}
		}
}
