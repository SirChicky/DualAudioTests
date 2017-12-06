using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Generator : MonoBehaviour {
	public GameObject bullet;
	private GameObject obj;
	public Transform canon;
	public float time;
	public float power;

	// Update is called once per frame
	void Update () {
		/*if (Input.GetButtonDown("Fire1")) {
			Vector3 start = transform.position;
			start += transform.forward.normalized * power;
			{
				GameObject obj = (GameObject)Instantiate (bullet, start, transform.rotation);//bref il faut trouver un moyen dobtenir un game object sans rigidbody
				obj.GetComponent<Rigidbody>().velocity;
			}*/
		/*Rigidbody bulletInstance;
		bulletInstance = Instantiate (bullet, canon.position, canon.rotation) as Rigidbody;
		bulletInstance.AddForce (canon.forward * power);*/
		
		//}


}
}
