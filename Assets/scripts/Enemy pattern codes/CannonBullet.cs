using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour {

	public GameObject explosion;
	private Vector3 explosionPos;
	public bool _hasExploded = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider Other)
	{

		if (Other.gameObject.CompareTag ("Soil")) {
			explosionPos = gameObject.transform.position;
			if (_hasExploded == false) {
				GameObject explo = Instantiate (explosion);
				explo.transform.position = explosionPos;
				_hasExploded = true;
			}
			if (_hasExploded == true) {
				Destroy (gameObject);
			}
		}
	}
}
