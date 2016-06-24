using UnityEngine;
using System.Collections;

public class GlobalBucketControl : MonoBehaviour {

	private float speedIncrement = 1;

	IEnumerator RunSpeedUpdater () {
		while (StaticVars.canPlay) {
			yield return new WaitForSeconds(StaticVars.tick);
			StaticVars.globalSpeed += speedIncrement;
		}
	}

	void Start () {
		StartCoroutine (RunSpeedUpdater());

	}
}
