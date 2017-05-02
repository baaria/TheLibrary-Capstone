using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordFly : MonoBehaviour {

	//after instantiation, lift up and start flying around
	public float timer = 0f;
	public bool liftoff = false; 

	public float index;

	public float speed = 0.1f;

	public float MaxY = 10f;
	public float MinY = 0f;

	public float yVal;
	public float width;
	public float height;

	private bool decreasing = false;
	// Use this for initialization
	void Start () {
		Invoke ("WordsFlying", 10f);
		yVal = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(!liftoff) {
			float y = gameObject.transform.position.y + 0.2f;
			float z = gameObject.transform.position.z + 0.3f;
			float x = gameObject.transform.position.x - 0.1f;

			transform.position = new Vector3 (x, y, z);
		}

		if (liftoff) {
			//float y = gameObject.transform.position.y + 0.2f;
			timer += Time.deltaTime * speed;
			float x = Mathf.Cos (timer) * width;
			float z = Mathf.Sin (timer) * height;

			//increase y unitl you reach max, then decrease until you reach min
			if (!decreasing) {
				yVal += 0.2f;
				if (yVal >= MaxY) {
					decreasing = true;
				}
			} else if (decreasing) {
				yVal -= 0.2f;
				if (yVal <= MinY) {
					decreasing = false;
				}
			}
			transform.position = new Vector3 (x, yVal, z);

		}
	}

	void WordsFlying () {
		liftoff = true;
		//if already liftoff begin orbit and randomly flying around

	}
}
