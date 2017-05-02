using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPen : MonoBehaviour {

	//public Vector3 startingpoint;
	private float amplitudeX = 0.25f;
	private float amplitudeY = 1.25f;
	private float omegaX = 0.5f;
	private float omegaZ = 2.5f;
	public float index;
	public Transform startingpt;


	// Use this for initialization
	void Start () {
	//	startingpoint = transform.position;	
		//y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		index += Time.deltaTime;
		float x = amplitudeX * Mathf.Cos (omegaX * index);
		float z = Mathf.Abs (amplitudeY * Mathf.Sin (omegaZ * index));
		//Debug.Log ("x value is: " + (startingpt.transform.position.x + x) + "/ z value is: " + (startingpt.transform.position.z+z));
		transform.localPosition = new Vector3 (x+0.2f, 0.76f, z-0.21f);
	}
}
