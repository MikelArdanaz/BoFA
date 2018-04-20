using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public float TotalTime = 180.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		targetTime -= Time.deltaTime;
		if (targetTime <= 0.0f){
			timerEnded();
		}
	}
	void timerEnded(){
		SceneManager.LoadScene("end");
	}
}
