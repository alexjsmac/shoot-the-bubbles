using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// Gui component for counting text
	public Text scoreText;

	// score counter
	public int score;

	PlayerController(){
	}

	// Use this for initialization
	public void Start () {
		score = 0;
		scoreText.text = "Score: " + score.ToString();

	}
	
	public void UpdateScore ()
	{
		score += 100;
		scoreText.text = "Score: " + score.ToString();
		score += 100;
		print ("Update score!");
	}
}
