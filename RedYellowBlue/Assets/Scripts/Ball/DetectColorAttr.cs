using UnityEngine;
using System.Collections;

public class DetectColorAttr : MonoBehaviour {

	private Color colorAttr;


	void Start () {
		colorAttr = GetComponent<Renderer>().material.GetColor("_Color");
	}
	// Use this for initialization
	void OnTriggerEnter (Collider _c) {
		print(colorAttr);
		print(_c.GetComponent<BucketBase>().colorAttr);
		if(colorAttr.ToString() == _c.GetComponent<BucketBase>().colorAttr.ToString()){
			print ("Same");
		} else {
			print("BAD");
		}
	}

}
