using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerText; 
	public int TotalTime = 180;

	// Use this for initialization
	void Start () {
		StartCoroutine ("timer");
	}

	void UpdateTimer(){
		int minutes = (int)(TotalTime / 60);
		int seconds = (int)(TotalTime % 60);

		timerText.text = minutes.ToString() + ":" + seconds.ToString ();
	}

	IEnumerator timer(){
		while (TotalTime > 0f) {
			UpdateTimer ();
			yield return new WaitForSeconds (1);
			TotalTime -= 1;
		}
	}
		
	// Update is called once per frame
	void Update () {
		/*TotalTime -= Time.deltaTime;
		if (TotalTime <= 0.0f){
			timerEnded();
		}*/
	}
	void timerEnded(){
		SceneManager.LoadScene("end");
	}
}
