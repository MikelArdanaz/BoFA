using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeCloud : MonoBehaviour {

	public float _speed = 1f;
	public float _smokeDamage;
	public float fleeRadius = 2;

	Alert _alert;

	//GameObject[] _goalLocations;
	Vector3 _destination;

	float _xMin;
	float _xMax;
	float _zMin;
	float _zMax;

	// Use this for initialization
	void Start () {
		_alert = Camera.main.GetComponent<Alert> ();

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

	public void Flee(Vector3 position){
		Vector3 fleeDirection, newGoal;
		float x, z;

		fleeDirection = (this.transform.position - position).normalized;
		newGoal = this.transform.position + fleeDirection * fleeRadius;
		x = (newGoal.x < _xMin) ? _xMin : newGoal.x;
		x = (x > _xMax) ? _xMax : x;
		z = ( newGoal.z < _zMin) ? _zMin : newGoal.z;;
		z = (z > _zMax) ? _zMax : z;
		position = new Vector3 (x ,0, z);
		_destination = position;
	}

	public void Gather(Vector3 position){
		_destination = position;
	}

	void OnTriggerStay(Collider other){
		NPC npc;

		npc = other.GetComponent<NPC> ();
		if (npc != null) {
			npc.DecreaseLife (_smokeDamage * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other){
		NPC npc;

		npc = other.gameObject.GetComponent<NPC> ();
		if (npc != null && _alert != null) {
			_alert.NotifyNPCInSmog (npc.transform.position);
		}
	}

	// Update is called once per frame
	void LateUpdate () {
		Vector3 distance;

		//distance = _destination - transform.position;
		distance = new Vector3 (_destination.x - transform.position.x, 0, _destination.z - transform.position.z);
		if (distance.magnitude < 0.5f) {
			_destination = new Vector3 (Random.Range (_xMin, _xMax), 0, Random.Range (_zMin, _zMax));
		} else {
			transform.Translate (distance.normalized * Time.deltaTime * _speed);
		}
	}
}
