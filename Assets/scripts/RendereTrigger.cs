
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendereTrigger : MonoBehaviour {
		public Renderer rend;
	    public Collider body;
	    public float timerApparition;
	    public bool reApparition;
	    private float timerOrigin;

	void Awake(){

		timerOrigin = timerApparition;

	}

		void Start()
		{
			rend = GetComponent<Renderer>();
			rend.enabled = true;
		    body.enabled = true;
		    reApparition = true;
		    timerApparition = 0;
		Debug.Log ("0");
		}

		// Toggle the Object's visibility each second.
	void Invisible()
		{
		reApparition = false;
		}

	void Visible()
	{
		if (reApparition == false) {
			reApparition = true;
			timerApparition = timerOrigin;
		}
	}


	void Update(){
		if (timerApparition != 0) {
			timerApparition -= 1 * Time.deltaTime;
		}
		if (reApparition==true && timerApparition<=0.0f) {
			rend.enabled = true;
			body.enabled = true;
		}
		if (reApparition==false) {
			rend.enabled = false;
			body.enabled = false;
		}
	}
	}
	
