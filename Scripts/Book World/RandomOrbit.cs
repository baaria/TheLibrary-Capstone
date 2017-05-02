using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOrbit : MonoBehaviour {

	//WHAT HAPPENS IN THIS SCRIPT
	// the books swirl around the the player in a sort of "orbit"
	// at the same time they are rotating
	//they also dont move staight, they move up and down

	public float timer = 0f;
	public float flappyBird;
	public float speed;

	public GameObject book;
	public float width;
	public float height;
	public float y;




	// Use this for initialization
	void Start () {
		//transform.rotation = Random.rotation;
		speed = 0.01f;
	}
	
	// Update is called once per frame
	void Update () {
		//speed = 10f;
		//width = 2f;
		//height = 1f;
		y = Mathf.Sin(timer);//+10;

		timer += Time.deltaTime + speed;
		float x = Mathf.Cos (timer) * width;
		float z = Mathf.Sin (timer) * height;

		transform.position = new Vector3 (x, y, z);

	}
}
