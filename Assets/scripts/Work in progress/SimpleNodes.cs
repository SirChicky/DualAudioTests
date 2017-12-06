using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleNodes : MonoBehaviour {
	public List<GameObject> positions = new List<GameObject> ();
	// Use this for initialization

	private bool stop;
	private bool stopTheMachine;
	public float speed;
	public bool loop;
	public int iam;
	public bool changeCoordonate;
	void Awake(){
		changeCoordonate = false;
		iam=0;
	}
	void Update () {
		failSafe ();
		FailSafe2 ();

		if (stopTheMachine == false) {
			transform.position = Vector3.MoveTowards (transform.position, positions [iam].transform.position, Time.deltaTime * speed);
			if (gameObject.transform.position == positions [iam].transform.position && loop==false) {
				Spawn ();	             
			}
			if (gameObject.transform.position == positions [iam].transform.position && loop==true) {
				changeCoordonate = true;
					if (changeCoordonate==true)
					{
					iam += 1;
					changeCoordonate=false;
					}
			if (iam>=positions.Capacity)
				{ changeCoordonate = true;
							if (changeCoordonate==true)
							{		
								iam = 0;
								changeCoordonate=false;
							}
							}
					}
	}
	}



		void Spawn(){
		positions.Remove(positions[iam]);
		}
		void FailSafe(){
			if (stopTheMachine == false) {
			if (positions.Count == 1) {
					Debug.Log ("the end");
					if (stop == true) {
						stopTheMachine = true;
					}

				}
			}
		}
	void FailSafe2 ()
	{
		if (stopTheMachine == false && stop == false) {
			if ( positions.Count == 2 ) {
				Debug.Log ("the end");
				positions.Add (positions [1]);
				stop = true;

			}
		}
	}	

	void failSafe ()
	{
		if (stopTheMachine == false) {
			if ( positions.Count == 1 ) {
				Debug.Log ("the end");
				if (stop == true) {
					stopTheMachine = true;
				}
			}
}
}
}
