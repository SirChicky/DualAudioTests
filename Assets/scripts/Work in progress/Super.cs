using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super : MonoBehaviour {
	public float speed;
	public float selfDestruct;
	
	// Update is called once per frame
	void Update () {
		selfDestruct -= 1 * Time.deltaTime;
		transform.position += transform.forward * (Time.deltaTime * speed);
		if (selfDestruct<=0){
		Destroy (this.gameObject);
	}
}
}