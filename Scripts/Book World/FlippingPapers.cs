using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippingPapers : MonoBehaviour {

	public GameObject displayImage;

	void OnTouch() {
		displayImage.SetActiveRecursively (true);

	}

	void UnTouch() {
		displayImage.SetActiveRecursively (false);
	}
}
