using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FiringManagement : MonoBehaviour {
	public UnityEvent fire;
	bool firing = false;
	// Use this for initialization
	void Start () {
		fire = new UnityEvent();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.K) && !firing)
		{
			StartCoroutine(AutoFire(0.3f));
		}

	}

	IEnumerator AutoFire(float checktime)
	{
		firing = true;
		while (firing)
		{
			fire.Invoke();

			yield return new WaitForSeconds(checktime);

			firing = Input.GetKey(KeyCode.K);

		}

	}

}
