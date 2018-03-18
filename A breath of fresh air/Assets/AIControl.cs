using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

	GameObject[] _goalLocations;
	UnityEngine.AI.NavMeshAgent _agent;
	Animator _anim;
	float _speedMult;


	// Use this for initialization
	void Start () {
		_goalLocations = GameObject.FindGameObjectsWithTag("goal");
		_agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
		_agent.SetDestination(_goalLocations[Random.Range(0,_goalLocations.Length)].transform.position);
		_anim = this.GetComponent<Animator> ();
		_speedMult = Random.Range (0.1f, 1.5f);
		_agent.speed *= _speedMult;
		if (_anim != null) {
			_anim.SetFloat ("wOffset", Random.Range(0,1));
			_anim.SetTrigger ("isWalking");
			_anim.SetFloat ("speedMult", _speedMult);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_agent.remainingDistance < 1){
			_agent.SetDestination(_goalLocations[Random.Range(0,_goalLocations.Length)].transform.position);
		}
	}
}
