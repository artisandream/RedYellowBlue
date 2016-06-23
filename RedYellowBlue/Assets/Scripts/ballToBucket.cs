using UnityEngine;
using System.Collections;

public class ballToBucket : MonoBehaviour {

	//public Color ballColor;

	public GameObject ball;
	public int xPosition;
	public int yPosition;
	public int zPosition;

	void OnTriggerEnter(Collider whichBall)
	{

		Destroy(whichBall.gameObject);

		Instantiate (ball, new Vector3(xPosition,yPosition,zPosition), Quaternion.identity);

	}
		
}
