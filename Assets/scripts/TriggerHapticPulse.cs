using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHapticPulse : MonoBehaviour  {
	
	//SteamVR_TrackedObject trackedObj;

	void Awake ()
	{
		// var trackedObj = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
			//GetComponent<SteamVR_TrackedObject>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider Other)
	{
		if (Other.gameObject.CompareTag ("Bullet")) {
			Debug.Log ("Wack!");
			var trackedObj = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
			SteamVR_Controller.Input (trackedObj).TriggerHapticPulse (3999);
		}
	}
}