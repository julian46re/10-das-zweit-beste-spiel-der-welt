using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Escape)) {

			if (GameIsPaused) {

				Resume();

			} else {

				Pause();

			}

		}

	}

	public void Resume() {

		//GetComponent<camControl>.enabled = true;
		GameObject.Find("MainCamera").GetComponent<camControl>().enabled = true;
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;

	}

	public void Pause() {

		//GetComponent<camControl>.enabled = false;
		GameObject.Find("MainCamera").GetComponent<camControl>().enabled = false;
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	//public void LoadMenu() {
	//	Debug.Log("Hello Menu");
	//}

	//public void QuitGame() {

	//	Debug.Log("Quitter");

	//}

}

