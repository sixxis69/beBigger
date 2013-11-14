﻿using UnityEngine;
using System.Collections;

public class ExplosionTest : MonoBehaviour
{
		public float radius = 5.0F;
		public float power = 10.0F;

		void Start ()
		{
				Vector3 explosionPos = transform.position;
				Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
				foreach (Collider hit in colliders) {
						if (!hit)

						if (hit.rigidbody)
								Debug.Log ("explosion");
						hit.rigidbody.AddExplosionForce (power, explosionPos, radius, 3.0F);

				}
		}
}
