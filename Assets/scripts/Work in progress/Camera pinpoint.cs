using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerapinpoint : MonoBehaviour {
		public Camera newcamera;
	private RaycastHit hit;
	public GameObject laser;
	public bool touchNothing;
	private Ray ray;
	public bool nothit;

		void Start(){
	}


		void Update(){
		    int layer_mask = LayerMask.GetMask ("Enemy");
		    Vector3 noAngle = newcamera.transform.position;
		    Vector3 newVector = noAngle;
			Debug.DrawRay (transform.position, newVector, Color.magenta);
			ray = new Ray (transform.position, newVector); 
			if (Physics.Raycast (ray, out hit, Mathf.Infinity * 10, layer_mask)) {
				Debug.Log ("touche un truc");
				if (hit.collider.tag == "Player") {
					hit.transform.SendMessage ("HitByRay");
					Debug.Log ("toucheplayer");
				} 
			
			}
				// Do something with the object that was hit by the raycast.
			}
		}
	

