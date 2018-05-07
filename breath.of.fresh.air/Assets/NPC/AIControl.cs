using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

	GameObject[] _goalLocations;
	UnityEngine.AI.NavMeshAgent _agent;
	Animator _anim;
	float _speedMult;
	float detectionRadius = 10;
	float fleeRadius = 2;


	float _xMin;
	float _xMax;
	float _zMin;
	float _zMax;


	// Use this for initialization
	void Start () {
		GameObject[] bounds;

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

	void ResetAgent(){
		_speedMult = Random.Range (0.1f, 1.5f);
		_agent.speed = 2 * _speedMult;
		_agent.angularSpeed = 120;
		if (_anim != null){
			_anim.SetFloat("speedMult", _speedMult);
			_anim.SetTrigger("isWalking");
		}
		_agent.ResetPath();
	}

	NavMeshPath CalculatePath(Vector3 position){
		Vector3 fleeDirection, newGoal;
		NavMeshPath path;

		fleeDirection = (this.transform.position - position).normalized;
		newGoal = this.transform.position + fleeDirection * fleeRadius;
		path = new NavMeshPath ();
		_agent.CalculatePath (newGoal, path);
		while (path.status == NavMeshPathStatus.PathInvalid) {
			newGoal += fleeDirection;
			path = new NavMeshPath ();
			_agent.CalculatePath (newGoal, path);
			/*Debug.Log (newGoal);
			Debug.Log (_xMin + " " + _xMax);
			Debug.Log (_zMin + " " + _zMax);*/
			if (newGoal.x < _xMin || newGoal.x > _xMax) {
				Debug.Log (newGoal + " X:" + _xMin + " " + _xMax);
				Debug.Log ((newGoal.x < _xMin) + " " + (newGoal.x > _xMax));
				return null;
			}
			if (newGoal.z < _zMin || newGoal.z > _zMax) {
				Debug.Log ((newGoal.z < _zMin) + " " + (newGoal.z > _zMax));
				Debug.Log (newGoal + " Z:" + _zMin + " " + _zMax);
				return null;
			}
		}
		_agent.CalculatePath (newGoal, path);
		return path;
	}
		
	public void Flee(Vector3 position)
	{
//		Vector3 fleeDirection, newGoal;
		NavMeshPath path;

		if (Vector3.Distance (position, this.transform.position) < detectionRadius) {
			/*fleeDirection = (this.transform.position - position).normalized;
			newGoal = this.transform.position + fleeDirection * fleeRadius;
			path = new NavMeshPath ();
			_agent.CalculatePath (newGoal, path);*/
			path = CalculatePath (position);
			if (path != null){//path.status != NavMeshPathStatus.PathInvalid) {
				Debug.Log("valid path");
				_agent.SetDestination (path.corners [path.corners.Length - 1]);
				if (_anim != null) {
					_anim.SetTrigger ("isRunning");
				}
				_agent.speed = 10;
				_agent.angularSpeed = 500;
			} else
				Debug.Log ("invalid path");
		}
	}

	public void Gather(Vector3 position){
		_agent.SetDestination (position);
	}

	// Update is called once per frame
	void Update () {
		if (_agent.remainingDistance < 1){
			_agent.SetDestination(_goalLocations[Random.Range(0,_goalLocations.Length)].transform.position);
		}
	}
}
