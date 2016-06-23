using UnityEngine;
using System.Collections;

public class GlobalBucketControl : MonoBehaviour {

	public float speedIncrement = 0.01f;
 //Coroutine updates the global bucket speed every tick
	IEnumerator RunSpeedUpdater () {
		while (StaticVars.canPlay) {
			yield return new WaitForSeconds(StaticVars.tick);
			StaticVars.globalSpeed -= speedIncrement;
		}
	}

	void Start () {
		StartCoroutine (RunSpeedUpdater());

	}

}
