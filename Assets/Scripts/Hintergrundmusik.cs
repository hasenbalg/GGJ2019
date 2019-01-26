using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hintergrundmusik : MonoBehaviour {

	public AudioSource[] audioSources = new AudioSource[3];


	// Use this for initialization
	void Start () {
		audioSources [0].mute = true;
		audioSources [1].mute = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectsWithTag("Family").Length == 2 ) {
			audioSources [2].mute = true;
			audioSources [1].mute = false;
		} 
		if(GameObject.FindGameObjectsWithTag("Family").Length == 1 ) {
			audioSources [1].mute = true;
			audioSources [0].mute = false;
		} 
	}
}
