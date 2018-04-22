using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalCounter : MonoBehaviour {
	NPC[] NPCs;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		NPCs=FindObjectsOfType<NPC> ();
		int TotalNPCs = NPCs.Length;
	}
}
