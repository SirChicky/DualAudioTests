using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLaunch : MonoBehaviour 
{
	public GameObject bullet;
	public int timer;
	private int originTimer;
	private Vector3 target;
	private Vector3 spawn;
	
	// Update is called once per frame
	void Awake(){
		originTimer = timer;

	}
	void Update () 
	{ 
		timer = timer - 1;
		transform.LookAt (target);
		if (timer<=0)
		{
			Vector3 start = transform.position;

			{
				GameObject obj = (GameObject)Instantiate (bullet, start, transform.rotation);
				obj.GetComponent<BulletMovement>().newTarget = transform;
				timer = originTimer;
			}

		}

	}
}
