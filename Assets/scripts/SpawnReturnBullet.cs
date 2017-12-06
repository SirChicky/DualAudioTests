using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnReturnBullet : MonoBehaviour {

	public GameObject returnBullet;
	//public Vector3 detectedVelocity = gameObject.GetComponent<BulletMovement> ().triggerVelocity;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReturnBullet()
	{
		GameObject rBullet = (GameObject)Instantiate (returnBullet, transform.position, transform.rotation);
		rBullet.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<BulletMovement> ().triggerVelocity;
	}
}
