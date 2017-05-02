using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenePortal : MonoBehaviour {

    public Collider playerCollider1;
    public GameObject rig;
    public string sceneToLoad;
    public GameObject spawnPos;
    public bool spawnPosLoc;

	// Use this for initialization
	void OnTriggerEnter(Collider other)
    {
        if(other == playerCollider1)
        {
            SteamVR_LoadLevel.Begin(sceneToLoad);
            if(spawnPosLoc)
            {
                rig.transform.position = spawnPos.transform.position;
            }
            
            

        }
    }
}
