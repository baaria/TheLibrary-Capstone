using UnityEngine;
using System.Collections;

public class TreePool : MonoBehaviour {

	static int numTrees = 20;
	public GameObject treePrefab;
	static GameObject[] trees;

	// Use this for initialization
	void Start () {
	
		trees = new GameObject[numTrees];
		for(int i = 0; i < numTrees; i++)
		{
			trees[i] = (GameObject) Instantiate(treePrefab, Vector3.zero, Quaternion.identity);
            trees[i] = (GameObject)Instantiate(treePrefab, Vector3.zero, Quaternion.identity);
            trees[i].transform.rotation = Quaternion.Euler(0, Random.Range(-90, 90), 0);
			trees[i].SetActive(false);
		}

	}
	
	
	static public GameObject getTree()
	{
		for(int i = 0; i < numTrees; i++)
		{
			if(!trees[i].activeSelf)
			{
				return trees[i];
			}
		}
		return null;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
