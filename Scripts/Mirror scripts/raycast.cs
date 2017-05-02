using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour {

	public bool recursive;
	public float raycastRange;

	private Camera headsetCam;
	private LineRenderer raycastLine;


	//turn off mirror unitl raycast
	//turn of mirror script, mirror camera, & 
	RaycastHit hit;
	// Use this for initialization
	void Start () {
		raycastLine = GetComponent<LineRenderer> ();
		headsetCam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Physics.Raycast (transform.position, transform.forward, out hit, raycastRange)) {

			if (hit.collider.tag == "mirror") {
				
				if (hit.collider.gameObject.GetComponentInParent<MirrorScript> ()) {

					hit.collider.gameObject.GetComponentInParent<MirrorScript> ().MirrorRecursion = true;
					hit.collider.gameObject.GetComponent<MirrorReflectionScript> ().enabled = true;
					hit.collider.transform.parent.Find ("MirrorCamera").gameObject.GetComponent<MirrorCameraScript> ().enabled = true;
				} else {
					return;
				}
			}
		} 

//		if (recursive) {
//			Vector3 rayOrigin = headsetCam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0));
//			RaycastHit raycastHit;
//		}
		
	}
}
