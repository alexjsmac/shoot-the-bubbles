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

	public AudioClip gameOverSound;
	private AudioSource source;

	Animator anim;                          // Reference to the animator component.

	// Use this for initialization
	public void Start () {
		score = 0;
		scoreText.text = "Score: " + score.ToString();
		healthRemaining = health;
		source = GetComponent<AudioSource> ();
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
			endGame ();
		}
	}

	public void endGame() {
		// ... tell the animator the game is over.
		//source.PlayOneShot (gameOverSound, 1f);
		anim.SetTrigger ("GameOver");
	}

	public void increaseHealth() {

		// If the player has run out of health...
		if(healthRemaining != 100)
		{
			healthRemaining += 10;
			greenHealthBar.transform.localScale = new Vector3 (healthRemaining/100, 1, 1);

		}
	}

	void Awake ()
	{
		// Set up the reference.
		anim = GetComponent <Animator> ();
	}
}
