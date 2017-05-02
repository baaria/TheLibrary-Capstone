using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownCollider : MonoBehaviour {
    public Collider playa;
    public GameObject clown;
    public GameObject noFace;

    // Use this for initialization
    void Start()
    {
        clown.SetActive(false);
        noFace.SetActive(true);
    }

	void OnTriggerEnter(Collider other)
    {
        if(GetComponent<Collider>() == playa)
        {
            clown.SetActive(true);
            noFace.SetActive(false);
        }

    }

    void OnTriggerExit(Collider other)
    {
        clown.SetActive(false);
        noFace.SetActive(true);
    }
}
