using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCylinder : MonoBehaviour {

	//public GameObject obstacle;
	GameObject[] agents;
	GameObject[] smokes;

	// Use this for initialization
	void Start () {
		agents = GameObject.FindGameObjectsWithTag ("npc");
		smokes = GameObject.FindGameObjectsWithTag ("smoke");
	}

	void CallFlee(){
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray.origin, ray.direction, out hitInfo)) {
				if (hitInfo.collider.name != "Ground")
					return;
				//Instantiate (obstacle, hitInfo.point, obstacle.transform.rotation);
				foreach (GameObject a in agents) {
					a.GetComponent<AIControl> ().Flee (hitInfo.point);
				}
			}
		}
	}

	void CallGather(){
		if (Input.GetMouseButtonDown (1)) {
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray.origin, ray.direction, out hitInfo)) {
				if (hitInfo.collider.name != "Ground")
					return;
				Debug.Log ("Gather");
				//Instantiate (obstacle, hitInfo.point, obstacle.transform.rotation);
				foreach (GameObject a in agents) {
					a.GetComponent<AIControl> ().Gather (hitInfo.point);
				}
			}
		}
	}

	void CallSmokeFlee(){
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray.origin, ray.direction, out hitInfo)) {
				if (hitInfo.collider.name != "Ground")
					return;
//				Instantiate (obstacle, hitInfo.point, obstacle.transform.rotation);
				foreach (GameObject a in smokes) {
					a.GetComponent<smokeCloud> ().Flee (hitInfo.point);
				}
			}
		}
	}

	void CallSmokeGather(){
		if (Input.GetMouseButtonDown (1)) {
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray.origin, ray.direction, out hitInfo)) {
				if (hitInfo.collider.name != "Ground")
					return;
				Debug.Log ("Gather");
				//Instantiate (obstacle, hitInfo.point, obstacle.transform.rotation);
				foreach (GameObject a in agents) {
					a.GetComponent<AIControl> ().Gather (hitInfo.point);
				}
			}
		}
	}


	// Update is called once per frame
	void Update () {
		//CallFlee ();
		//CallGather();
		CallSmokeFlee();
		CallSmokeGather ();
	}
}
