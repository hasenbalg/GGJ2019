﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScreen : MonoBehaviour {
    public int sceneIndex;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            startGame();
        }
    }

	public void startGame () {
		SceneManager.LoadScene(sceneIndex);
	}

}
