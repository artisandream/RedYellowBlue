using UnityEngine;
using System.Collections;
using System;

public class BucketBase : MonoBehaviour {

	Action Move;
	public static Action<BucketBase> AddThisToSpawner;

	private Color nextColor;
	private Vector3 currentPosition;
	private Renderer materialRender;

	void MoveBucket ()
	{
		currentPosition.y = StaticVars.globalSpeed;
		transform.Translate (currentPosition);
	}

	void Update () {
		if (Move != null)
			Move ();
	}

	void Start (){
		print (this);
		//if(AddThisToSpawner != null)
			AddThisToSpawner(this);
		materialRender = GetComponent<Renderer>();
		ChangeColor();
	}

	void ChangeColor () {
		nextColor = GameColor.RandomColor();
		materialRender.material.SetColor("_Color", nextColor);
		materialRender.material.SetColor("_EmissionColor", nextColor);
	}

	public IEnumerator RespawnBucket () {
		ChangeColor();
		Move = MoveBucket;
		transform.position = StaticVars.resetPosition;
		yield return null;
	}

	void OnTriggerEnter () {
		Move = null;
	}
}
