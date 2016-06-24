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

	IEnumerator RunSpawnPositionUpdater () {
		while (StaticVars.canPlay) {
			StartCoroutine(RealRandomNum());
			StaticVars.resetPosition.x = newRandomNum;
			lastRandomNum = newRandomNum;
			yield return new WaitForSeconds(0.1f);
		}

		StartCoroutine(RunSpawnPositionUpdater());
		yield return null;
	}
		
	public void SpawnBucket () {
		print(i);
		print(buckets.Count);
		if(i<buckets.Count-1){
			i++;
		} else {
			i=0;
		}
		StartCoroutine(buckets[i].RespawnBucket());
	}

	void AddBuckets (BucketBase _b) {
		buckets.Add(_b);
	}

	void Start () {
		BucketBase.AddThisToSpawner += AddBuckets;
		StaticVars.resetPosition.y = 7;
		BucketMover.CallSpawn = SpawnBucket;
		buckets = new List<BucketBase>();
		StartCoroutine(RunSpawnPositionUpdater());
	}
}
