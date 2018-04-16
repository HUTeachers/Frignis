using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatBack : MonoBehaviour {
	Vector3 speed = Vector3.zero;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.SmoothDamp(transform.position, transform.parent.position, ref speed, 0.11f);	
	}


}
