using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTarget_Position : MonoBehaviour {

	public Transform myTarget;
	public Transform myCannon;
	//public GameObject aimTarget;
	//public float shootAngle;
	private float distance;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		myTarget = GameObject.FindWithTag ("Player").transform;
		distance = Vector3.Distance(myCannon.position, myTarget.position)/ 1.3f;
		transform.position = (transform.position - myTarget.position).normalized * distance + myTarget.position;
		transform.position = new Vector3(transform.position.x, distance / 1.9f, transform.position.z);
	}
}
