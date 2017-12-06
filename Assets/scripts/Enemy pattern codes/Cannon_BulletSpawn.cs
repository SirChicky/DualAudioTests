using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_BulletSpawn : MonoBehaviour {

	public Transform myTarget;
	public float shootAngle;
	public int timer;
	public GameObject cannonBall;

	private int originTimer;

	void Awake () {
		originTimer = timer;
	}

	// Use this for initialization
	void Start () {

	}

	Vector3 BallisiticVel (Transform target, float angle)
	{
			var dir = target.position - transform.position; // get target direction
			float h = dir.y; // get height difference
			//dir.y = 0; // retain only the horizontal direction
			float distance = dir.magnitude; // get horizontal distance
			float a = angle * Mathf.Deg2Rad; // convert angle to radians
			dir.y = Mathf.Tan (a); // set dir to the elevation angle
			distance += h / Mathf.Tan (a); // correct for small height differences
			// calculate the velocity magnitude
			float vel = Mathf.Sqrt (distance * Physics2D.gravity.magnitude / Mathf.Sin (2 * a));

			return vel * dir.normalized;
	}

	// Update is called once per frame
	void FixedUpdate () {

		//AutoShot
		timer -= 1;
		if (timer <= 0) {
				GameObject ball = Instantiate (cannonBall, transform.position, Quaternion.identity) as GameObject;
				Rigidbody ball_rb = ball.GetComponent<Rigidbody> ();
				ball_rb.velocity = BallisiticVel (myTarget, shootAngle);
				Destroy (ball, 7);
				timer = originTimer;

		}
			
		//Manual Shoot
		/*if (Input.GetKeyDown (KeyCode.B)) {
			GameObject ball = Instantiate (cannonBall, transform.position, Quaternion.identity) as GameObject;
			Rigidbody ball_rb = ball.GetComponent<Rigidbody> ();
			ball_rb.velocity = BallisiticVel (myTarget, shootAngle);
			Destroy (ball, 7);
		}*/
	}
}
