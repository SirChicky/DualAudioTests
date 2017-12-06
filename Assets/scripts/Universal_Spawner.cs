using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universal_Spawner : MonoBehaviour {

	public List<float> timer = new List<float> ();
	public List<GameObject> enemies = new List<GameObject> ();
	public List<Transform> spawnposition = new List<Transform> ();
	public List<bool> followers = new List<bool> ();
	public List<bool> leader = new List<bool> ();
	private int spawnsOrigin;
	private int spawnsNumber;
	private bool stop;
	private bool stopTheMachine;
	private GameObject[] spawnsNumber2;
	public int spawnsStart;
	void Awake(){
		spawnsOrigin = 0;
		spawnsNumber = spawnsStart;
		stopTheMachine = false;
		stop = false;
		if (spawnsStart == 0) {
			spawnsNumber = 1;
		}
	}

	void Update () {
		if (spawnsStart > 0) {
			Spawn ();
			spawnsStart -= 1;
		}

	

		FailSafe ();
		FailSafe2 ();
		spawnsNumber2=GameObject.FindGameObjectsWithTag ("Enemy");
		if (stopTheMachine == false) {
			if (leader [0] == true) {
				spawnsNumber = 0;
				if (spawnsNumber2.Length == spawnsNumber) {
					if (spawnsStart <= 0 && spawnsNumber == 0) {
						timer [0] -= Time.deltaTime;
						if (timer [0] <= 0.0f) {
							Spawn ();
							spawnsNumber = spawnsNumber2.Length;
						}
					}
				}
			}
		}
		if (stopTheMachine == false) {
			if (leader [0] == false ) {
				if ((spawnsNumber != spawnsNumber2.Length) || followers [0] == true) {
					if (spawnsStart <= 0 && spawnsNumber >= 0) {
						timer [0] -= Time.deltaTime;
						if (timer [0] <= 0.0f) {
							Spawn ();
							spawnsNumber = spawnsNumber2.Length;
						}
					}
				}
			}
		}
	}
	void Spawn(){
		Instantiate (enemies[0],spawnposition[0]);
		enemies.Remove(enemies[0]) ;
		spawnposition.Remove(spawnposition[0]);
		timer.Remove (timer [0]);
		followers.Remove(followers[0]);
		leader.Remove (leader[0]);

	}
	void FailSafe(){
		if (stopTheMachine == false) {
			if (enemies.Count == 1 || timer.Count == 1 ||  spawnposition.Count == 1 || followers.Count == 1 || leader.Count == 1) {
				Debug.Log ("the end");
				if (stop == true) {
					stopTheMachine = true;
				}

			}
		}
	}
			void FailSafe2(){
		if (stopTheMachine == false&&stop==false) {
			if (enemies.Count ==2 || timer.Count == 2 || spawnposition.Count == 2 ||followers.Count == 2 || leader.Count == 2) {
						Debug.Log ("the end");
						enemies.Add (enemies [1]);
						spawnposition.Add(spawnposition[1]);
				 		timer.Add(timer [1]);
				        followers.Add(followers[1]);
				        leader.Add (leader [1]);
						stop = true;

					}
		}

	//}
}
}