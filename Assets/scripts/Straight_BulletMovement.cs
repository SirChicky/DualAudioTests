using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straight_BulletMovement : MonoBehaviour {

	public GameObject _target;
	public GameObject _newTarget;
	public Transform target;
	public GameObject hpmanager;
	private HP hpPlayeraccess;
	public int damage;
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
	void Start () {
		rb = GetComponent<Rigidbody> ();
		_target = GameObject.FindWithTag ("Player");
		target = _target.transform;
		targetPosition = _target.transform.position /*+ new Vector3(gameObject.transform.position.x/2, 0, 0)*/;
		rend = GetComponent<Renderer> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isDeflected) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, targetPosition, step);
		}else{
			if (newTarget != null) {
				Vector3 directionTowardsEnemy = (newTarget.position - transform.position).normalized;
				//Rotate bullet towards enemy progressively
				transform.forward = Vector3.Lerp (transform.forward, directionTowardsEnemy, homingSpeed);
			}
			//Linear movement == The bullet will move forward
			transform.position += transform.forward * (Time.deltaTime * speed * returnSpeedMultiplier);
			//transform.position = Vector3.Lerp (transform.position, newTarget.position, Time.deltaTime * speed*2);
		}

	}

	void OnTriggerEnter(Collider Other)
	{

		if (Other.gameObject.CompareTag ("Player")) {
			Debug.Log ("Poke");
			hpPlayeraccess = hpmanager.GetComponent<HP> ();
			hpPlayeraccess.hpPlayer -= damage;
			Destroy (gameObject);

		}
		if (Other.gameObject.CompareTag ("Sword") && !isDeflected) {
			Debug.Log ("Whack");
			rend.material.color = Color.black;
			gameObject.tag = ("BulletBack");
			isDeflected = true;

			//Give the sword direction to the bullet
			transform.forward = Other.GetComponent<Moving_Sword>().currentSpeed.normalized;

		}

		if (Other.gameObject.CompareTag ("BulletDetector") && this.gameObject.tag==(currentTag)) {
			Debug.Log ("Beep!");

		}

		if (Other.gameObject.tag == "IdleSword") {
			Destroy (this.gameObject);
		}

		if (Other.gameObject.tag == "Enemy") {
			Destroy (this.gameObject, 3.0f);
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
