using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	float SignedAngleBetween(Vector3 a, Vector3 b, Vector3 n){
		// angle in [0,180]
		float angle = Vector3.Angle(a,b);
		float sign = Mathf.Sign(Vector3.Dot(n,Vector3.Cross(a,b)));

		// angle in [-179,180]
		float signed_angle = angle * sign;

		// angle in [0,360] (not used but included here for completeness)
		float angle360 =  (signed_angle + 180) % 360;

		return angle360;
	}

	public void NotifyNPCInSmog(Vector3 position) {
		float dir1, dir2;
		string axis1, axis2;

		dir1 = transform.position.x - position.x;
		dir2 = transform.position.z - position.z;

		if (dir1 > 0) {
			axis1 = "East";
		} else {
			dir1 = -dir1;
			axis1 = "West";
		}

		if (dir2 > 0) {
			axis2 = "South";
		} else {
			dir2 = -dir2;
			axis2 = "North";
		}

		if (dir1 > dir2) {
			Debug.Log (axis1);
		} else {
			Debug.Log (axis2);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
