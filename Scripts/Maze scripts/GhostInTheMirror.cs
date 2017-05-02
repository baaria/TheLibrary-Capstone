using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostInTheMirror : MonoBehaviour {
    public GameObject mirror;
    public GameObject ghost;

    public float ghostRadar = 0.75f; //at half a meter show ghost 
    RaycastHit hits;

	// Use this for initialization
	void Start () {
        ghost.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Physics.Raycast(transform.position,transform.forward, out hits, ghostRadar))
        {
            ghost.SetActive(true);
        } else
        {
            ghost.SetActive(false);
        }
	}
}
