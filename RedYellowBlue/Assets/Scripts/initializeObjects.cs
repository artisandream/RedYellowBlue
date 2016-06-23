using UnityEngine;
using System.Collections;

public class initializeObjects : MonoBehaviour {

	Color red = Color.red;
	//Color yellow = Color.yellow;
	//Color blue = Color.blue;

	public char ballColor;

	// Use this for initialization
	void Start () {

		//if (ballColor = "R")
		{	
			Renderer rend = GetComponent<Renderer>();
			//rend.material.shader = Shader.Find("Specular");
			rend.material.SetColor("blueBall", red);
		}
	
	}

}
