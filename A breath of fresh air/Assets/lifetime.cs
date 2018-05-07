using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifetime : MonoBehaviour {

	float time = 5f;
	float passed = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (passed >= time)
			Destroy (gameObject);
		passed += Time.deltaTime;
		
	}
}
