using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropCylinder : MonoBehaviour {

	public Text currentPower;

	public GameObject obstacle;
	GameObject[] agents;
	GameObject[] smokes;

	int action = 1;

	// Use this for initialization
	void Start () {
		agents = GameObject.FindGameObjectsWithTag ("npc");
		smokes = GameObject.FindGameObjectsWithTag ("smoke");
		currentPower.text = "Crowd Flee";
	}

	void CallFlee(){
		if (Input.GetMouseButtonDown (0) && action == 1) {
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray.origin, ray.direction, out hitInfo)) {
				if (hitInfo.collider.name != "Ground")
					return;
				Instantiate (obstacle, hitInfo.point, obstacle.transform.rotation);
				foreach (GameObject a in agents) {
					if (a != null)
						a.GetComponent<AIControl> ().Flee (hitInfo.point);
				}
			}
		}
	}

	void CallGather(){
		if (Input.GetMouseButtonDown (0) && action == 2) {
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray.origin, ray.direction, out hitInfo)) {
				if (hitInfo.collider.name != "Ground")
					return;
				Debug.Log ("Gather");
				Instantiate (obstacle, hitInfo.point, obstacle.transform.rotation);
				foreach (GameObject a in agents) {
					if (a != null)
						a.GetComponent<AIControl> ().Gather (hitInfo.point);
				}
			}
		}
	}

	void CallSmokeFlee(){
		if (Input.GetMouseButtonDown (0) && action == 3) {
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray.origin, ray.direction, out hitInfo)) {
				if (hitInfo.collider.name != "Ground")
					return;
				Instantiate (obstacle, hitInfo.point, obstacle.transform.rotation);
				foreach (GameObject a in smokes) {
					if (a == null)
						a.GetComponent<smokeCloud> ().Flee (hitInfo.point);
				}
			}
		}
	}

	void CallSmokeGather(){
		if (Input.GetMouseButtonDown (0) && action == 4) {
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray.origin, ray.direction, out hitInfo)) {
				if (hitInfo.collider.name != "Ground")
					return;
				Debug.Log ("Gather");
				Instantiate (obstacle, hitInfo.point, obstacle.transform.rotation);
				foreach (GameObject a in agents) {
					if (a == null)
						a.GetComponent<AIControl> ().Gather (hitInfo.point);
				}
			}
		}
	}

	/*void Point(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.transform.name == "") {
				//
			}
		}
	}*/

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			action = 1;
			currentPower.text = "Crowd Flee";
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			action = 2;
			currentPower.text = "Crowd Gather";
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			action = 3;
			currentPower.text = "Smoke Flee";
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			action = 4;
			currentPower.text = "Smoke Gather";
		}

		CallFlee ();
		CallGather ();
		CallSmokeFlee ();
		CallSmokeGather ();
			
	}
}
