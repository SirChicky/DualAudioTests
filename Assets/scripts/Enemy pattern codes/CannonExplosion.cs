using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonExplosion : MonoBehaviour {

	private float timer;

	// Use this for initialization
	void Start () {
		timer = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localScale += new Vector3(0.025f, 0.025f, 0.025f);
		timer = timer - 1.0f * Time.deltaTime;
		if (timer <= 0) {
			Destroy(gameObject);
		}

	}
}
