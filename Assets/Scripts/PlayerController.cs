using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// Gui component for counting text
	public Text scoreText;

	// score counter
	public int score;


	// Use this for initialization
	public void Start () {
		score = 0;
		UpdateScore ();
	}
	
	public void UpdateScore ()
	{
		scoreText.text = "Score: " + score.ToString();
	}
}
