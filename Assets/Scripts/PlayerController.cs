using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// Gui component for counting text
	public Text scoreText;
	public int score;

	public float health = 100f;
	public float healthRemaining= 0f;
	public Image greenHealthBar;

	Animator anim;                          // Reference to the animator component.

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

		healthRemaining -= 10;
		greenHealthBar.transform.localScale = new Vector3 (healthRemaining/100, 1, 1);

		// If the player has run out of health...
		if(healthRemaining <= 0)
		{
			// ... tell the animator the game is over.
			anim.SetTrigger ("GameOver");
		}
	}

	void Awake ()
	{
		// Set up the reference.
		anim = GetComponent <Animator> ();
	}
}
