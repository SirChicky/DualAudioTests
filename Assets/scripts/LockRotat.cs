using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotat : MonoBehaviour {
	float lockPos = 0;
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.y, lockPos, lockPos); //Used to lock and Free some angles for rotation purposes
	}
}