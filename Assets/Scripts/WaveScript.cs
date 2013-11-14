using UnityEngine;
using System.Collections;

public class WaveScript : MonoBehaviour
{
		public GameObject smallPrefab;
		public GameObject bigPrefab;
		public TextMesh countdownText;
		public int currentWave;
		public GameObject player;

		void Start ()
		{
				
				currentWave = 1;
				StartCoroutine (CreateWave ());
		}

		public IEnumerator CreateWave ()
		{
				countdownText.transform.localPosition = Vector3.zero;
				countdownText.text = "Wave " + currentWave;
				iTween.MoveBy (countdownText.gameObject, iTween.Hash ("z", 20, "easeType", "easeInOutExpo"));

				yield return new WaitForSeconds (1.5f);

				iTween.MoveBy (countdownText.gameObject, iTween.Hash ("z", -30, "easeType", "easeInOutExpo"));

				yield return new WaitForSeconds (.5f);

				CreateEnemy ();
				currentWave++;
		}

		void CreateEnemy ()
		{
				int numSmall = (currentWave % 2) * 3 + 3;

				int numBig = (int)Mathf.Floor (currentWave / 2) + 1;

				CreateSmall (numSmall);
				CreateBig (numBig);
		}

		void CreateSmall (int num)
		{
				int radius = 10;
				float stepAngle = 360 / num;
					
				float radian;
				float posX;
				float posZ;

				for (int i=0; i<num; i++) {
						
						radian = Mathf.Deg2Rad * i * stepAngle;
						posX = Mathf.Cos (radian) * radius + player.transform.position.x;
						posZ = Mathf.Sin (radian) * radius + player.transform.position.z;
						Instantiate (smallPrefab, new Vector3 (posX, 0.25f, posZ), Quaternion.identity);	
				}
		}

		void CreateBig (int num)
		{
				float marginX = 50;
				float widthX = (num - 1) * marginX;
				float posX;
				float posZ = player.transform.position.z + 20;

				for (int i=0; i<num; i++) {
						if (i == 0) {
								posX = 0;
						} else {
								posX = (i * marginX) - (widthX * 0.5f);
						}				
						
						Instantiate (bigPrefab, new Vector3 (posX, 1f, posZ), Quaternion.identity);	
				}
		}
}
