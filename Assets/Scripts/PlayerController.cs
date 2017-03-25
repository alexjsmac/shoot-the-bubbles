using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// Gui component for counting text
	public Text scoreText;

	// score counter
	public int score;

	public void Start(){
		scoreText = GameObject.Find("Text").GetComponent<Text>();
		scoreText.text = "Score: " + score.ToString();
	}
	
	public void UpdateScore ()
	{
		scoreText.text = "Score: " + score.ToString();
		score += 100;
		print ("Update score!");
	}
}
