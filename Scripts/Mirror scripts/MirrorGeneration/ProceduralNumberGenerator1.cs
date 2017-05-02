using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralNumberGenerator1 {
	public static int currentPosition;
	public const string key = "12342412334242143223314444123344441212334432121223344";

	public static int getNextNumber() {
		string currentNum = key.Substring (currentPosition++ % key.Length, 1);
		//return int.Parse(currentNum);
		return Random.Range(1,5);
	}
}
