using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackoutAI : MonoBehaviour {

	//in this script, when the player collides with the black blobs
	//their screen goes dark
	//they hear weird sounds
	//for a few seconds before fading back to normal
	//maybe its a red filter for a while
	public GameObject blackScreen;
	private bool isIncreasing;
	public float minX;
	public float maxX;
	public float minZ;
	public float maxZ;
	private AudioSource audio;

    public float raycastDist = 15f;

	public bool direction;

    private RaycastHit hit;

    public int sceneToLoad = 2;

	// Use this for initialization
	void Start () {
		//set the color of the panel to transparent
		blackScreen.GetComponent<Image>().enabled = false;
		//Invoke ("BlackoutBlackout", 5f);
		audio = GetComponent<AudioSource>(); 

		if (direction) {
			if (transform.position.x < (maxX + minX) / 2) {
				isIncreasing = true;
			} else {
				isIncreasing = false;
			}
		} else if (!direction) {
			if (transform.position.z < (maxZ + minZ) / 2) {
				isIncreasing = true;
			} else {
				isIncreasing = false;
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (direction) {
			// go in the X direction
			float xPos = transform.position.x;
			if (isIncreasing) {
				xPos = transform.position.x + 0.01f;
				if (xPos >= maxX) {
					isIncreasing = false;
				}
			} else if (!isIncreasing) {
				xPos = transform.position.x - 0.01f;
				if (xPos <= minX) {
					isIncreasing = true;

				}
			}
	
			transform.position = new Vector3 (xPos, transform.position.y, transform.position.z);
		} else if (!direction) {
			//go in the Z direction
			float zPos = transform.position.z;
			if (isIncreasing) {
				zPos += 0.01f;
				if (zPos >= maxZ) {
					isIncreasing = false;
				} 
			} else if (!isIncreasing) {
				zPos -= 0.05f;
				if (zPos <= minZ) {
					isIncreasing = true;

				}
			}
			transform.position = new Vector3 (transform.position.x, transform.position.y, zPos);
		}
        
        if(Physics.Raycast(transform.position,transform.forward, out hit, raycastDist))
        {
            if(hit.collider.tag == "Player")
            {
                Vector3 playerPos = hit.collider.gameObject.transform.position;
                Vector3 npsPos = transform.position;
                Vector3 delta = new Vector3(playerPos.x - npsPos.x, 0.0f, playerPos.z - npsPos.z);

                Quaternion rotation = Quaternion.LookRotation(delta);
            }
        }
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			BlackoutBlackout ();
		}
	}

	void BlackoutBlackout() {
		//set color of panel to black
		blackScreen.GetComponent<Image>().enabled = true;
		audio.Play ();
		Invoke ("BackToBlack", 5f);

	}

	void BackToBlack() {
        SceneManager.LoadScene(sceneToLoad);
		blackScreen.GetComponent<Image> ().enabled = false;
	}
}
