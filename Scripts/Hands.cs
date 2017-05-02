using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour {

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	public GameObject handprint;
	public float timer = 5f;
	public float repeatRate;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Handpress", timer, repeatRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Handpress() {
		Vector3 transformPos = new Vector3(Random.Range (minX, maxX), Random.Range (minY, maxY), transform.position.z);
		GameObject handstance = Instantiate (handprint, transformPos, Quaternion.identity);
		handstance.transform.rotation = Quaternion.Euler (0, 0, Random.Range (-67f, 57f));
		Destroy (handstance, 7f);

	}


}
