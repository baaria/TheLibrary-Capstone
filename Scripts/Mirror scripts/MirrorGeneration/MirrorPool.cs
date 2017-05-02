using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPool : MonoBehaviour {

    //over a period of 9 tiles how to distribute mirrors in a seeminly randomized way
    //but have them be at the position needed to be should you return to that tile

	static int numMirrors = 200;
	public GameObject mirrorPrefab;
	static GameObject[] mirrors;

	// Use this for initialization
	void Start () {
		mirrors = new GameObject[numMirrors];
		for (int i = 0; i < numMirrors; i++) {
			mirrors [i] = (GameObject)Instantiate (mirrorPrefab, Vector3.zero, Quaternion.identity);
			mirrors [i].SetActive (false);
		}
	}

	static public GameObject getMirror() {
		for (int i = 0; i < numMirrors; i++) {
			if (!mirrors [i].activeSelf) {
				return mirrors [i];
			}
		}
		return null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
