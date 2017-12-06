using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupSpawn : MonoBehaviour {

	//public GameObject enemy;
	//private GameObject myenemy;
	public Transform[] enemiesTransform;
	public GameObject[] enemies;
	List<GameObject> actualEnemies;
	public int enemyNumber;
	//public Transform[] spawnPoints;
	//List<Transform> actualSpawns;
	//public bool existence;
	public float timer;
	private float timerOrigin;
	private int numberenemiesOrigin;

	void Awake(){
		timerOrigin = timer;
		//actualSpawns = new List<Transform> (spawnPoints);
	}
	void Start(){

		//SpawnEnnemy ();
		//enemies = new GameObject [enemyNumber];
		enemiesTransform = gameObject.GetComponentsInChildren<Transform>();
		enemies = new GameObject [enemiesTransform.Length];

	}

	void Update () {
		// If the player has no health left...
		timer= timer-(Time.deltaTime);
		if (timer <= 0) {
			//for (int i = 0; i < enemies.Lenght; i++) 
			foreach(GameObject actualEnemies in enemies)
			{
				//enemies.SetActive(true);
				timer = timerOrigin;
			}
		}
		/*if (timer <= 0 && numberenemies>0) {
			// Find a random index between zero and one less than the number of spawn points.

			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			SpawnEnnemy();
			timer = timerOrigin;
		}*/
	}
	/*if (numberenemies <=0 && GameObject.FindGameObjectWithTag("Enemy")==null) {
		Destroy (this.gameObject);
	}*/


	/*void SpawnEnnemy()
	{
		int spawnPointIndex = Random.Range (0, actualSpawns.Count);
		myenemy = Instantiate (enemy, actualSpawns [spawnPointIndex].position, actualSpawns [spawnPointIndex].rotation);
		numberenemies = numberenemies -1;
		actualSpawns.RemoveAt (spawnPointIndex);
		if (actualSpawns.Count == 0)
			actualSpawns = new List<Transform> (spawnPoints);
	}*/
}
