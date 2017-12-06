using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSuper : MonoBehaviour {
	public bool activation;
	public float timer;
	public float boost;
	public GameObject Super;
	public float originTimer;
	void Awake(){
		originTimer = timer;

	}
	void Start(){
		activation = false;
		timer = 30;
		Debug.Log ("waiting time:" + timer);
	}
	// Update is called once per frame
	void Update () {
		if (timer > 0.0f) {
			timer = timer - (1* Time.deltaTime);
		}
		if (timer<= 0.0f && activation == true) {
			Vector3 start = transform.position;

			{
				GameObject obj = (GameObject)Instantiate (Super, start, transform.rotation);
				timer = originTimer;
				activation = false;

				}
	}
}
	void HitByRay3 () {
		if (timer > 0) {
			timer = timer - (boost * Time.deltaTime);
			Debug.Log ("I Block a Ray");
		} else {
			Debug.Log("already charged");
		}
}
}
