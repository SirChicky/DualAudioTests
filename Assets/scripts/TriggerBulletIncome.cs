using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBulletIncome : MonoBehaviour {

	public bool bulletEntered;
	private bool alertPlayed;
	public AudioClip bulletAlert;
	public AudioSource source;
	private float alertCooldown;

	// Use this for initialization
	void Start () {
		bulletEntered = false;
		//source = GetComponent<AudioSource>();
		alertCooldown = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {

		if (bulletEntered == true && alertPlayed == false) {
			source.PlayOneShot (bulletAlert);
			alertPlayed = true;
		}

		if (bulletEntered == true && alertPlayed == true) {
			alertCooldown -= Time.deltaTime;
		}

		if (alertCooldown <= 0)	{
			bulletEntered = false;
			alertPlayed = false;
		}
		//Debug.Log (alertCooldown);
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Bullet") {
			bulletEntered = true;
			alertCooldown = 3.0f;
		}

	}
}
