using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
	Material mat;
	float _health = 100;

	// Use this for initialization
	void Start () {
		mat = GetComponent<Renderer> ().material;
		//mat.color = new Color (0,255,0);
		mat.color = Color.green;
	}

	void SetColor(){
		if (_health > 60 && _health < 80) {
			mat.color = Color.yellow;
		}
		if (_health > 40 && _health < 60) {
			mat.color = new Color (237f/255f, 127f/255f, 16f/255f);
			//mat.color = new Color ( 16f/255f, 127f/255f, 237f/255f);
		}
		if (_health < 30) {
			mat.color = Color.red;
		}
	}

	public void DecreaseLife(float damage){
		_health -= damage;
		SetColor ();
		if (_health <= 0f) {
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
