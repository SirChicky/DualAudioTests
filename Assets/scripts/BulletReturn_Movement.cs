using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletReturn_Movement : MonoBehaviour {

	public GameObject _target;
	public Transform target;
	public Vector3 targetPosition;
	public float speed;
	private Renderer rend;

	// Use this for initialization
	void Start () 
	{
		_target = GameObject.FindWithTag ("Player");
		target = _target.transform;
		targetPosition = _target.transform.position;
		rend = GetComponent<Renderer> ();
	}

	// Update is called once per frame
	void Update () 
	{

		//targetPosition = new Vector3 (_target.transform.position.x, _target.transform.position.y, _target.transform.position.z);
		//targetPosition = _target.transform.position;
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, targetPosition, step);

	}

	void OnTriggerEnter(Collider Other)
	{

		/*if (Other.gameObject.CompareTag ("Player")) {
			Debug.Log ("Poke");
			Destroy (gameObject);

		}*/

		if (Other.gameObject.CompareTag ("BulletDetector") && this.gameObject.tag==("Bullet")) {
			Debug.Log ("Beep!");
			gameObject.tag = ("BulletDetected");
		}

		/*if (Other.gameObject.tag == "IdleSword") {
			Destroy (this.gameObject);
			//Debug.Log ("KIKOO");
		}*/

		if (Other.gameObject.tag == "Enemy") {
			Destroy (this.gameObject, 3.0f);
			//Debug.Log ("JOJO");
		}

		/*if (Other.gameObject.tag == "Detection") {
			Light lightComp = this.gameObject.AddComponent<Light>();
			lightComp.color = Color.blue;

		}*/

		if (Other.gameObject.tag == "LevelBorder") {
			Destroy (this.gameObject);
			Debug.Log ("BorderHit");
		}

	}
		
}
