using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRay : MonoBehaviour {

		private GameObject target;
		private Transform targetPoint;
		private Quaternion targetRotation;

		void Start () 
		{
			target = GameObject.FindWithTag("Player");
		}

		void Update()
		{ 
			transform.LookAt (target.transform);
			//targetPoint = new Transform(target);
			//targetRotation = Quaternion.LookRotation(targetPoint);
			//transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
		}

	}
