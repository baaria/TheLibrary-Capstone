using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemFly : MonoBehaviour {

	//instantiate at spawn position
	//instantiate in order of poem
	//after instantiate fly around crazily
	//if you go through list, start over + reinstantiate from zero

	public Transform spawnPosition;
	public GameObject[] poetry;
	private float timer = 5f;
	public int counter;

	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("SpawnWords", timer, timer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnWords() {
		Instantiate(poetry[counter], spawnPosition.transform.position, Quaternion.identity);
		counter++;

		if (counter >= poetry.Length) {
			counter = 0;
		}
	}
}
