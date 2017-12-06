using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {
	public float hpPlayer;
	public float damgeOverTime;
	private float hpPlayerOrigin;
	public float bombeDansTaFace;

	private BulletMovement bulletMovementaccess;
	private Straight_BulletMovement straightBulletMovementaccess;
	// Use this for initialization
	void Awake () {
		hpPlayerOrigin = hpPlayer;
	}
	void Start(){
		hpPlayer = hpPlayerOrigin;
	}
		//Debug.Log ("" + hpPlayer);	
		void HitByRay () {
		hpPlayer -= damgeOverTime * Time.deltaTime;
			Debug.Log ("I was hit by a Ray");
		}
	void Bakugan(){
		hpPlayer -= bombeDansTaFace;
	}
		}
	

