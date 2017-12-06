using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : MonoBehaviour 
{
	public GameObject firePillar;
	public Transform player;
	public float timer;

	// Use this for initialization
	void Start () 
	{
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer = timer + 1;

			if (timer == 500)

			{
				StartCoroutine ("Attack");

			}



	}

	private IEnumerator Attack()
	{
		Instantiate (firePillar, player.position, player.rotation) /*as GameObject*/;
		//WaitForSeconds (3.0);
		timer = 0;
		yield break;
	}



}
