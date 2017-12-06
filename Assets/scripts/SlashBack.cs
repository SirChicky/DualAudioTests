using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashBack : MonoBehaviour {
	public GameObject recever;

	void OnTriggerEnter(Collider Other){
		if (Other.gameObject.CompareTag ("Sword") || (Other.gameObject.CompareTag ("IdleSword"))) {
			recever.tag = "BackSlash";
		}
	} 

	void OnTriggerStay(Collider Other){
		if (Other.gameObject.CompareTag ("Sword")||(Other.gameObject.CompareTag ("IdleSword"))){
			recever.tag = "BackSlash";
			} 
			

			else{
				
			recever.tag = "Untagged";
		}
		
	}
}

