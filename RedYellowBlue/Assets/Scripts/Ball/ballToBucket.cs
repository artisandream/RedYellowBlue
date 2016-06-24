using UnityEngine;
using System.Collections;

public class ballToBucket : MonoBehaviour {

	//public Color ballColor;

	public GameObject ball;
	public int xPosition;
	public int yPosition;
	public int zPosition;

	public Color ObjectColor;
	private Color currentColor;
	private Renderer rend;

	void OnTriggerEnter(Collider whichBall)
	{

		Instantiate (ball, new Vector3(xPosition,yPosition,zPosition), Quaternion.identity);

		rend = GetComponent<Renderer>();
		rend.enabled = true;

		rend.material.SetColor("_Color", ObjectColor);
		rend.material.SetColor("_EmissionColor", ObjectColor);

		print (ObjectColor);

		Destroy(ball.gameObject);

	}
		
}
