using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public int sceneIndex = 1;
    public float radius;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	

    void FixedUpdate ()
    {

        if (Mathf.Abs(this.transform.position.x - player.transform.position.x)< radius)
        {
            if(Mathf.Abs(player.transform.position.z - this.transform.position.z) < radius)
            {
                Debug.Log("Entering maze of mirrors");
               // SceneManager.LoadScene(sceneIndex);
            }
            //LoadScene(sceneIndex);
        }
    }
	
    
}
