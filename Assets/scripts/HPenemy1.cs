using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPenemy1 : MonoBehaviour {
	public float hp;
	public float damgeOverTime;
	public float damages;
	public GameObject SuperSword;  
	// Update is called once per frame
	void Update () {
		//Debug.Log(""+ hp);
		if (hp <= 0) {
			Destroy(this.gameObject);

		}

		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log ("Mort");
			Destroy (this.gameObject);
		}
	}
	void OnTriggerEnter(Collider Other)
	{
		if (Other.gameObject.CompareTag ("BulletBack")) {
			hp = hp - damages;
			//Debug.Log("touche");
		}
		if (Other.gameObject.CompareTag ("Sword") ||Other.gameObject.CompareTag ("IdleSword")||Other.gameObject.CompareTag ("VoidSword")||Other.gameObject.CompareTag ("VoidIdleSword")) {
			Instantiate(SuperSword);
			Destroy(this.gameObject);
		}
	}
		void HitByRay2 () {
			hp-= damgeOverTime * Time.deltaTime;
			Debug.Log ("I was hit by a Ray2");
		}

	}

