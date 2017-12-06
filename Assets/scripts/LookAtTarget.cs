using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour {

	public GameObject _target;
	public Transform target;
	public Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		_target = GameObject.FindWithTag ("Player");
		target = _target.transform;
		targetPosition = _target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target);
	}
}
