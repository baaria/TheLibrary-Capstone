using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEndDoor : MonoBehaviour {

	//when the mazeLoader reaches a dead end and must hunt again
	//instantiate door at deadend 
	//actually this script should be called dead end objects but thats okay.

	public GameObject deadEndObject;
	public Transform deadEndSpawn;
	//private HuntAndKillMazeAlgorithm huntAndKill;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void ReachedDeadEnd(Vector3 deadEndSpawnPos) {
		Debug.Log ("located dead end");
	}
}
