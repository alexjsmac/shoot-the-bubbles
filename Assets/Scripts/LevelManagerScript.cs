using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour {

	public Transform mainMenu, optionsMenu;

	public void LoadScene(string name){
		Application.LoadLevel (name);
	}
	public void QuitGame(){
		Application.Quit ();
	}
	public void OptionMenu(bool clicked){
		if (clicked == true) {
			optionsMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (false);
		} else {
			optionsMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (true);
		}
	}


}
