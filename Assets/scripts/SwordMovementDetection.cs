using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovementDetection :SteamVR_TrackedController  
{

	public Vector3 currentSpeed;
	//public GameObject parentSword;

	public float limitangx;
	public float limitangy;
	public float limitangz;
	public GameObject childSword;
	public bool voidActivated;
	public bool backActivated;
	private SteamVR_TrackedObject trackedObj;
	public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int) controllerIndex); } }
	public Vector3 velocity { get { return controller.velocity; } }
	public Vector3 angularVelocity { get { return controller.angularVelocity; } }


	Vector3 previousPosition;
	[SerializeField]
	float minMovementThreshold;
	[SerializeField]
	float maxMovementThreshold;


	void Start()
	{
		voidActivated = false;
		backActivated = true;
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		//instantiateTimer = 0.005f;
	}


	void Update()
	{
		Debug.DrawRay (transform.position, 3 * currentSpeed.normalized, Color.red, .1f);
		float dist = Vector3.Distance (previousPosition, transform.position);
		currentSpeed =  transform.position - previousPosition; 
		if (childSword.tag=="VoidSword"||childSword.tag=="VoidIdleSword")
		{
			voidActivated = true;
			backActivated = false;
		 
		}
		if (childSword.tag == "SwordBack") {
			backActivated = true;
			voidActivated = false;
		}
		//instantiateTimer -= Time.deltaTime;
		if (dist < minMovementThreshold /*|| dist > maxMovementThreshold*/)
		{
			if (voidActivated == true) {
				gameObject.tag = "VoidIdleSword";
				childSword.tag = "VoidIdleSword";
			}
			if (backActivated == true) {
				gameObject.tag = "IdleSword";
				childSword.tag = "IdleSword";
			}
		}		

		else 
		{
			if (voidActivated == true) {
				gameObject.tag = "VoidSword";
				childSword.tag = "VoidSword";
			}
			if (backActivated == true) {
				gameObject.tag = "Sword";
				childSword.tag = "Sword";
			}
		}


	}
	void LateUpdate()
	{
		previousPosition = transform.position;
	}

}