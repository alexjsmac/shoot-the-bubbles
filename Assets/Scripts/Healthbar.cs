﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	public float health = 100f;
	public float healthRemaining= 0f;


	// Use this for initialization
	void Start () {

		healthRemaining = health;
		InvokeRepeating ("decreaseHealth", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void decreaseHealth() {

		health -= 10;
	}
}
