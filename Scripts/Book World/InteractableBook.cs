using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using 

public class InteractableBook : MonoBehaviour {

	public GameObject currentlyTouched;

	void Touch() {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 10f)) {
			if (hit.collider.gameObject.tag == "Touchable") {
				//did it hit the paper
				//if so then show the paper
				hit.collider.gameObject.SendMessage("OnTouch");
				currentlyTouched = hit.collider.gameObject;
			}
		}
	}

	void Update() {
		if(Input.GetMouseButtonDown(0)) //if the player clicks with left button 
		{
			if (currentlyTouched == null) {
				Touch ();
				//then execute touch()
			} else {
				currentlyTouched.SendMessage ("UnTouch");
				currentlyTouched = null;
			}
		}
	}
}
