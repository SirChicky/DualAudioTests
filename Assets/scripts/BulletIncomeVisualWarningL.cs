using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIncomeVisualWarningL : MonoBehaviour 
{
	public GameObject leftWarning;
	public string detectionTag;
	public string newTag;

	// Use this for initialization
	void Start () 
	{
		leftWarning.SetActive (false);
	}

	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.tag == detectionTag) 
		{
			other.gameObject.tag = newTag;
			StartCoroutine ("Appear");
		}

	}

	IEnumerator Appear()
	{
		leftWarning.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		leftWarning.SetActive (false);
		yield break;
	}
}
