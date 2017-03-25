using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// Gui component for counting text
	public Text scoreText;

	// score counter
	public int score;

	public float health = 100f;

	public float healthRemaining= 0f;

	public Image greenHealthBar;

	// Use this for initialization
	public void Start () {
		score = 0;
		scoreText.text = "Score: " + score.ToString();
		healthRemaining = health;
	}
	
	public void UpdateScore ()
	{
		scoreText.text = "Score: " + score.ToString();
		score += 100;
	}

	public void decreaseHealth() {

		//healthRemaining -= 10;
		greenHealthBar.transform.localScale = new Vector3 (50, 1, 1);
	}
}
