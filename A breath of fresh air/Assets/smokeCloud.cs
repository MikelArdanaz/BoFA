using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeCloud : MonoBehaviour {

	public float _speed = 1f;
	public float _smokeDamage;

	GameObject[] _goalLocations;
	Vector3 _destination;

	// Use this for initialization
	void Start () {
		_goalLocations = GameObject.FindGameObjectsWithTag("smokeGoal");
		_destination = _goalLocations [Random.Range (0, _goalLocations.Length)].transform.position;
	}

	/*void OnTriggerEnter(Collider other){
		Debug.Log ("enter trigger");
	}

	void OnTriggerExit(Collider other){
		Debug.Log ("exit trigger");
	}*/

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
			_destination = _goalLocations [Random.Range (0, _goalLocations.Length)].transform.position;
		} else {
			transform.Translate (distance.normalized * Time.deltaTime * _speed);
		}
	}
}
