using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private GameObject[]  spawnPoints;
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag("Enemy") == null) {
			foreach (GameObject spawnPoint in spawnPoints) {
				GameObject enemy = Instantiate (enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
			}
		
		}
		
	}
}
