using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFeedback : MonoBehaviour {

	private Light redLight;
	private float lightOnTime;


	// Use this for initialization
	void Start () {
		redLight = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (redLight.enabled = true) {
			lightOnTime = -Time.deltaTime;
			if (lightOnTime < 0) {
				redLight.enabled = false;
			}
		}
	}

	void OnTriggerEnter(Collider Other)
	{
		if (Other.gameObject.CompareTag ("BulletBack")) {
			Debug.Log ("Boom");
			if (redLight.enabled = false) {
				lightOnTime = 60.0f;
				redLight.enabled = true;
			}
			//Destroy (gameObject);
		}
	}
}
