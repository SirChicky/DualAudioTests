using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlade : MonoBehaviour {

	private Valve.VR.EVRButtonId triggerButton=Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device trigger;
	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		trigger = SteamVR_Controller.Input ((int)trackedObject.index);
		if(trigger.GetPressDown(triggerButton))
		{
			Debug.Log ("triggered");
			trigger.TriggerHapticPulse (900);
		}
		
	}
}
