using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOnTheCamera : MonoBehaviour {
	public GameObject laCamera;
	public float speed;
	public bool gonflement;
	public float timer; 
	public GameObject player;
	void Start(){

		gonflement = false;
	}

	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindWithTag ("Player");
		laCamera = GameObject.FindWithTag ("AttrapeMouche");
		transform.position = Vector3.Lerp(transform.position, laCamera.transform.position, Time.deltaTime * speed);
	
	}
	void OnTriggerEnter(Collider Other){
		if (Other.gameObject.tag =="AttrapeMouche") {
			Debug.Log ("Yokai2");
		}
	}

	void OnTriggerStay(Collider Other){
		if (Other.gameObject.tag =="AttrapeMouche") {
			Debug.Log ("Yokai2");
			this.transform.localScale += new Vector3 (0.0025f, 0.0025f, 0.0025f);
			timer = timer - 1.0f * Time.deltaTime;
			if (timer <= 0) {
				player.SendMessage ("Bakugan");
				Destroy (this.gameObject);
			}
		}
	}
		
}

