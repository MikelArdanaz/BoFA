using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
	float _health = 100f;

	// Use this for initialization
	void Start () {
		
	}

	public void DecreaseLife(float damage){
		_health -= damage;
		if (_health <= 0f) {
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
