using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSuper : MonoBehaviour {
	public GameObject spawnerSuper;
	private SpawnerSuper spawnerSuperaccess;


	// Use this for initialization
	void OnTriggerEnter(Collider Other) {
		if (Other.gameObject.CompareTag ("Soil")) {
			spawnerSuperaccess = spawnerSuper.GetComponent<SpawnerSuper> ();
			spawnerSuperaccess.activation= true;
		
		}
		
	}

}
