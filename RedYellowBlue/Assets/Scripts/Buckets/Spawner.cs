using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Spawner : MonoBehaviour {

	Action ChangeTime;

	public List<BucketBase> buckets;
	private int i;

	private int[] spawnNums = {-2,-1,0,1,2,2};
	private int lastRandomNum;
	private int newRandomNum;

	IEnumerator RealRandomNum () {
		newRandomNum = spawnNums[UnityEngine.Random.Range(0,5)];
		while(lastRandomNum == newRandomNum) {
			newRandomNum = spawnNums[UnityEngine.Random.Range(0,5)];
			yield return null;
		}
	}

	void IncreaseTickTime () {
		if(StaticVars.spawnTick > 0.5f) {
			StaticVars.spawnTick -= 0.25f;
		} else {
			ChangeTime = null;
		}
	}

	IEnumerator RunPositionUpdater () {
		while (StaticVars.canPlay) {
			StartCoroutine(RealRandomNum());
			StaticVars.resetPosition.x = newRandomNum;
			lastRandomNum = newRandomNum;
			yield return new WaitForSeconds(StaticVars.spawnTick);
			if(ChangeTime != null)
				ChangeTime();

			if(i<buckets.Count){
				StartCoroutine(buckets[i].RespawnBucket());
				i++;
			} else {
				i=0;
			}
		}
		yield return null;
		StartCoroutine(RunPositionUpdater());
	}

	void AddBuckets (BucketBase _b) {
		buckets.Add(_b);
	}

	void Start () {
		print (this);
		buckets = new List<BucketBase>();
		BucketBase.AddThisToSpawner += AddBuckets;
		ChangeTime = IncreaseTickTime;
		StartCoroutine(RunPositionUpdater());
	}
}
