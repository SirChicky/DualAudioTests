using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehaviour : MonoBehaviour 
{
	public Transform player;
	public float speed;
	private float speedOrigin;
	void Awake (){
		speedOrigin = speed;

	}

	void Start(){
		speed = speedOrigin;
	
	}
	void Update(){
		//float step = speed * Time.deltaTime;
		transform.position = Vector3.Lerp(player.position, player.position, Time.deltaTime*speed);
	}
}
