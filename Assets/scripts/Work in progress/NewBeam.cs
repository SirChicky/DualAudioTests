using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBeam : MonoBehaviour {
	private RaycastHit hit;
	private Ray ray;
		void Update(){
		int layer_mask = LayerMask.GetMask("Player");
		int layer_mask2 = LayerMask.GetMask ("Sword");
		Debug.DrawRay (transform.position, Vector3.forward*100, Color.magenta);
		ray = new Ray (transform.position,Vector3.forward*100); 
		if (Physics.Raycast (ray, out hit, Mathf.Infinity * 10, layer_mask)) {
			Debug.Log ("touche un truc");
			if (hit.collider.tag == "Player") {
				hit.transform.SendMessage ("HitByRay");
				Debug.Log ("toucheplayer");
			}
		}
			if (Physics.Raycast (ray, out hit, Mathf.Infinity * 10, layer_mask2)) {
				Debug.Log ("touche un truc");
				if (hit.collider.tag == "IdleSword") {
					hit.transform.SendMessage ("HitByRay3");
					Debug.Log ("toucheSword");
				}
			}
		}
		}

