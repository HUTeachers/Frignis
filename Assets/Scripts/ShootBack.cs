using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBack : MonoBehaviour {
	Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		transform.parent.GetComponent<FiringManagement>().fire.AddListener(KickBack);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void KickBack()
	{
		rb2d.AddForce(-transform.right, ForceMode2D.Impulse);
	}
}
