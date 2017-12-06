using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity_Checking : MonoBehaviour {

		public Rigidbody blade;
		public float limitx;
		public float limity;
		public float limitz;

		// Use this for initialization
		void Start () {
			blade.GetComponent<Rigidbody> ();
			float x = blade.velocity.x;
			float y = blade.velocity.y;
			float z = blade.velocity.z;
		}

		// Update is called once per frame
		void Update () {

			if (blade.velocity.x>limitx)
			{
				Debug.Log ("oh my goodness");

			}

			if (blade.velocity.y>limity)
			{
				Debug.Log ("oh my god");

			}	if (blade.velocity.z>limitz)
			{
				Debug.Log ("oh no");

			}



		}
	}
