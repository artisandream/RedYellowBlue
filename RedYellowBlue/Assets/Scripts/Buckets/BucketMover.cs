using UnityEngine;
using System.Collections;
using System;

public class BucketMover : MonoBehaviour {

	public static Action CallSpawn;
	private Vector3 newPos;

	IEnumerator MoveBuckets () {
		newPos.x += StaticVars.moveIncrement;
		while(Vector3.Distance(transform.position, newPos) > 0.01f)
		{
			transform.position = Vector3.Lerp(transform.position, newPos, StaticVars.globalSpeed * Time.deltaTime);
			yield return null;
		}
		CallSpawn();
	}

	void MoveAgain () {
		StartCoroutine(MoveBuckets());
	}

	void Start () {
		BucketBase.MoveNext += MoveAgain;
		StartCoroutine(MoveBuckets());
	}
}
