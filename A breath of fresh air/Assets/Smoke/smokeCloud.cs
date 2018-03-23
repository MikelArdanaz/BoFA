﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeCloud : MonoBehaviour {

	public float _speed = 1f;
	public float _smokeDamage;

	//GameObject[] _goalLocations;
	Vector3 _destination;
	float _xMin;
	float _xMax;
	float _zMin;
	float _zMax;

	// Use this for initialization
	void Start () {
		GameObject[] bounds;
		float actualY;

		bounds = GameObject.FindGameObjectsWithTag ("fieldBound");
		if (bounds [0].transform.position.x < bounds [1].transform.position.x) {
			_xMin = bounds [0].transform.position.x;
			_xMax = bounds [1].transform.position.x;
			_zMin = bounds [0].transform.position.z;
			_zMax = bounds [1].transform.position.z;
		} else {
			_xMin = bounds [1].transform.position.x;
			_xMax = bounds [0].transform.position.x;
			_zMin = bounds [1].transform.position.z;
			_zMax = bounds [0].transform.position.z;
		}
		actualY = transform.position.y;
		_destination = new Vector3 (Random.Range (_xMin, _xMax), 0, Random.Range (_zMin, _zMax));
		transform.position = new Vector3(_destination.x, actualY, _destination.z);
	}

	void OnTriggerStay(Collider other){
		NPC npc;

		npc = other.GetComponent<NPC> ();
		if (npc != null) {
			npc.DecreaseLife (_smokeDamage * Time.deltaTime);
		}
	}

	// Update is called once per frame
	void LateUpdate () {
		Vector3 distance;

		distance = _destination - transform.position;
		distance = new Vector3 (_destination.x - transform.position.x, 0, _destination.z - transform.position.z);
		if (distance.magnitude < 0.5f) {
			_destination = new Vector3 (Random.Range (_xMin, _xMax), 0, Random.Range (_zMin, _zMax));
		} else {
			transform.Translate (distance.normalized * Time.deltaTime * _speed);
		}
	}
}
