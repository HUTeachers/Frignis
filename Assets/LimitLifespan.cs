using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitLifespan : MonoBehaviour {

	public float LifeTime = 4f;

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, LifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
