using UnityEngine;
using System.Collections;
using System;

public class BucketBase : MonoBehaviour {

	public static Action MoveNext;
	public static Action<BucketBase> AddThisToSpawner;
	public string colorAttr;

	private Vector3 startPos;
	private Color nextColor;
	public SpriteRenderer materialRender;
	private Transform thisParent;

	void ChangeColor () {
		nextColor = GameColor.RandomColor();
		nextColor.a = 10;
		materialRender.color = (nextColor);
		colorAttr = nextColor.ToString();
		print(colorAttr);
	}

	IEnumerator DropBucket () {
		ChangeColor();
		startPos = transform.position;
		while(startPos.y > 0.01f) {
			startPos.y = Mathf.Lerp(startPos.y, 0, StaticVars.globalSpeed*Time.deltaTime);
			transform.position = startPos;
			yield return null;
		}
		transform.parent = thisParent;
		MoveNext();
	}

	public IEnumerator RespawnBucket () {
		transform.parent = null;
		transform.position = StaticVars.resetPosition;
		StartCoroutine(DropBucket());
		yield return null;
	}

	void Start (){
		//materialRender = GetComponent<SpriteRenderer>();
		ChangeColor();
		thisParent = transform.parent;
		if(AddThisToSpawner != null)	
			AddThisToSpawner(this);
	}
}
