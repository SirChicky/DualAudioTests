using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Sword :SteamVR_TrackedController 
{
	//public GameObject sword;
	/*public float limitx;
	public float limity;
	public float limitz;*/

	public GameObject shadow;
	public Vector3 currentSpeed;
	//public GameObject parentSword;

	///public float limitangx;
	///public float limitangy;
	//public float limitangz;
	public float instantiateTimer;
	public Renderer render;
	//public GameObject voidSword;
	public GameObject twinSword;
	public GameObject voidParticle;
	public bool voidactive;
	public float timerVoid;
	private float timerVoidOrigin;
	//private int theChange;

	private SteamVR_TrackedObject trackedObj;
	public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int) controllerIndex); } }
	public Vector3 velocity { get { return controller.velocity; } }
	public Vector3 angularVelocity { get { return controller.angularVelocity; } }
	/*[SerializeField]
	float minMovementThreshold;
	[SerializeField]
	float maxMovementThreshold;*/

	Vector3 previousPosition;
	void Awake(){
		//theChange = 1;
		timerVoidOrigin = timerVoid;
	}

	void Start()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		instantiateTimer = 0.005f;
		voidParticle.SetActive(false);
	}
		

	void Update()
	{
		/*if ((twinSword.tag =="VoidIdleSword"||twinSword.tag =="VoidSword")&&(theChange>0)) {
			theVoid ();
			theChange = 0;
		}*/

		Debug.DrawRay (transform.position, 3 * currentSpeed.normalized, Color.red, .1f);
		//Debug.Log ("" + controller.velocity);
		//Debug.Log ("" + controller.angularVelocity);
		//Debug.Log (rb.velocity);
		float dist = Vector3.Distance (previousPosition, transform.position);
		currentSpeed =  transform.position - previousPosition; 
		//var shadowPosition = new Vector3(parentSword.position.x, parentSword.position.y, parentSword.position.z);
		//var shadowRotation = Quaternion.identity;

		instantiateTimer -= Time.deltaTime;
		/*if (dist < minMovementThreshold || dist > maxMovementThreshold)
		{
			gameObject.tag = "IdleSword";
		}		

		else 
		{
			gameObject.tag="Sword";
			if (instantiateTimer <= 0.0f) {
				Instantiate (shadow, transform.position, transform.rotation);
				instantiateTimer = 0.005f;
			}
		}*/
	
		if (gameObject.tag == "Sword") {
			if (instantiateTimer <= 0.0f) {
				Instantiate (shadow, transform.position, transform.rotation);
				instantiateTimer = 0.005f;
			}
		}
		if (gameObject.tag == "VoidSword") {
			if (instantiateTimer <= 0.0f) {
				Instantiate (shadow, transform.position, transform.rotation);
				instantiateTimer = 0.005f;
				render.material.color = Color.black;
				timerVoid -= Time.deltaTime;
				if (timerVoid <= 0.0) {
					theNormal ();
				}

			}
		}
			if (gameObject.tag == "VoidIdleSword") {
				render.material.color = Color.black;
				timerVoid -= Time.deltaTime;
				if (timerVoid<=0.0)
				{
					theNormal();
				}
			
			}
	}

	void LateUpdate(){
		previousPosition = transform.position;
	}

	void OnTriggerEnter (Collider Other)
	{
		
		if (Other.tag == "Void") {
			theVoid();

		}
}
	void theVoid(){
		gameObject.tag = ("VoidIdleSword");
		voidParticle.SetActive(true);
		voidactive = true;
	}
	void theNormal(){
		gameObject.tag = ("SwordBack");
		voidParticle.SetActive (false);
		voidactive = false;
		render.material.color = Color.red;
		timerVoid = timerVoidOrigin;
	}

}


