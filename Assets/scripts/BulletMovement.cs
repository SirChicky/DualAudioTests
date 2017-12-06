using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour 
{
	public GameObject _target;
	public GameObject _newTarget;
	public GameObject hpmanager;
	private HP hpPlayeraccess;
	public int damage;
	public Transform target;
	public Transform newTarget;
	public Vector3 targetPosition;
	[Tooltip("Regular speed of the bullet")]
	public float speed;
	[Tooltip("By how much should the speed be multiplied once you deflect the bullet")]
	public float returnSpeedMultiplier;
	public string currentTag;
	[Range(0.01f,.5f)]
	public float homingSpeed;
	public Rigidbody rb;
	public Vector3 triggerVelocity;

	private Renderer rend;
	private Color color= Color.white;

	public bool isDeflected;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		_target = GameObject.FindWithTag ("Player");
		target = _target.transform;
		targetPosition = _target.transform.position;
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(currentTag != gameObject.tag)
			currentTag = gameObject.tag;
		if (!isDeflected) {
			transform.LookAt (target);
			transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * speed);
		}
		else{
			if (newTarget != null) {
				Vector3 directionTowardsEnemy = (newTarget.position - transform.position).normalized;
				//Rotate bullet towards enemy progressively
				transform.forward = Vector3.Lerp (transform.forward, directionTowardsEnemy, homingSpeed);
			}
				//Linear movement == The bullet will move forward
			transform.position += transform.forward * (Time.deltaTime * speed * returnSpeedMultiplier);
			//transform.position = Vector3.Lerp (transform.position, newTarget.position, Time.deltaTime * speed*2);
		}

		//targetPosition = new Vector3 (_target.transform.position.x, _target.transform.position.y, _target.transform.position.z);
		//targetPosition = _target.transform.position;


		//float step = speed * Time.deltaTime;
		//transform.position = Vector3.MoveTowards (transform.position, targetPosition, step);

	}

	void OnTriggerEnter(Collider Other)
	{
		/*triggerSword = GetComponent<Rigidbody>();
		triggerVelocity = triggerSword.velocity;*/

		if (Other.gameObject.CompareTag ("Player")) {
			Debug.Log ("Poke");
			//hpPlayeraccess = hpmanager.GetComponent<HP> ();
			//hpPlayeraccess.hpPlayer -= damage;
			Destroy (gameObject);

		}
	if (Other.CompareTag ("BackSlash") && !isDeflected) {
			Debug.Log ("Whack");
			rend.material.color = Color.black;
			//speed = -speed;
			gameObject.tag = ("BulletBack");
			isDeflected = true;
			//Give the sword direction to the bullet
			transform.forward = -transform.forward;

		}
	else if (Other.CompareTag ("Sword") && !isDeflected) {
			Debug.Log ("Whack");
			rend.material.color = Color.black;
			//speed = -speed;
			gameObject.tag = ("BulletBack");
			isDeflected = true;
			//Give the sword direction to the bullet
			transform.forward = Other.GetComponent<Moving_Sword>().currentSpeed.normalized;
			//Debug.DrawRay (transform.position, Other.GetComponent<Moving_Sword> ().currentSpeed.normalized, Color.blue);
			//this.gameObject.GetComponent<SpawnReturnBullet> ().ReturnBullet ();
			//Debug.Log("ORA");
			//float step = speed * Time.deltaTime;
			//transform.position = Vector3.MoveTowards (transform.position, newTarget.position, step);

		}

		if (Other.gameObject.CompareTag ("BulletDetector") && this.gameObject.tag==(currentTag)) {
			Debug.Log ("Beep!");
			//gameObject.tag = (newTag);
		}

		/*if (Other.gameObject.CompareTag ("BulletDetector") && this.gameObject.tag==("BulletDetected")) {
			Debug.Log ("Beep!");
			gameObject.tag = ("BulletDetected2");
		}

		if (Other.gameObject.CompareTag ("BulletDetector") && this.gameObject.tag==("BulletDetected2")) {
			Debug.Log ("Beep!");
			gameObject.tag = ("BulletDetected3");
		}*/

		if (Other.gameObject.tag == "IdleSword") {
			Destroy (this.gameObject);
			//Debug.Log ("KIKOO");
		}
		if (Other.gameObject.tag == "Super") {
			Destroy (this.gameObject);
			//Debug.Log ("KIKOO");
		}
		if (Other.gameObject.tag == "Enemy") {
			Destroy (this.gameObject, 3.0f);
			//Debug.Log ("JOJO");
		}
		if (Other.gameObject.tag == "Detection") {
			Light lightComp = this.gameObject.AddComponent<Light>();
			lightComp.color = Color.blue;
		
		}

		if (Other.gameObject.tag == "LevelBorder") {
			Destroy (this.gameObject);
			Debug.Log ("BorderHit");
		}



	}
		
}


