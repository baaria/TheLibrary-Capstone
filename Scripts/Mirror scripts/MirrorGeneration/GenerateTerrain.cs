using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour {

	int heightScale = 5;
	float detailScale = 5.0f;
	// public GameObject mirror;
	List<GameObject> myMirrors = new List<GameObject>();

	// Use this for initialization
	void Start () {
		Mesh mesh = this.GetComponent<MeshFilter> ().mesh;
		Vector3[] vertices = mesh.vertices;
		for (int v = 0; v < vertices.Length; v++) {
			vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x)/detailScale,
			(vertices[v].z + this.transform.position.z)/detailScale)* heightScale;

			if (vertices [v].y > 2.6 && Mathf.PerlinNoise((vertices[v].x+5)/10, (vertices[v].z+5)/10)*10 > 4.6) {
				GameObject newMirror = MirrorPool.getMirror ();
				if (newMirror != null) {
					Vector3 mirrorPos = new Vector3 (vertices [v].x + this.transform.position.x,
						                    vertices [v].y,
						                    vertices [v].z + this.transform.position.z);
					newMirror.transform.position = mirrorPos;
					newMirror.SetActive (true);
					myMirrors.Add (newMirror);
					
				}
			}
		}

		mesh.vertices = vertices;
		mesh.RecalculateBounds ();
		mesh.RecalculateNormals ();
		this.gameObject.AddComponent<MeshCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy() {
		for (int i = 0; i < myMirrors.Count; i++) {
			if (myMirrors [i] != null) {
				myMirrors [i].SetActive (false);
			}
		}
		myMirrors.Clear ();
	}
}
