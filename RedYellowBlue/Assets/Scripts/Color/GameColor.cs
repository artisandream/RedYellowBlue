using UnityEngine;
using System.Collections;

public class GameColor {
	public static Color[] gameColors = {Color.red, Color.yellow, Color.green, Color.green};

	public static Color RandomColor () {
		Color newColor = gameColors[UnityEngine.Random.Range(0,3)];
		return newColor;
	}
}
