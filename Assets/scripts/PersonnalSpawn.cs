using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnalSpawn : MonoBehaviour {
	

		public GameObject enemy;
		private GameObject myenemy;
		public Transform[] spawnPoints;       
	    public bool existence;
	    public float timer;
	    private float timerOrigin;

	    void Awake()
	{
		timerOrigin = timer;
	}

	void Update () {
		

			// If the player has no health left...
		if(existence==true && myenemy==null)
			{
			  timer= timer-(Time.deltaTime);
			if (timer <= 0) {
				// Find a random index between zero and one less than the number of spawn points.
				int spawnPointIndex = Random.Range (0, spawnPoints.Length);

				// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
				myenemy = Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			
				timer = timerOrigin;
			    }
			}

	}
}

