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

	void Resume() {

		//GetComponent<camControl>.enabled = true;
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;

	}

	void Pause() {

		//GetComponent<camControl>.enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

}

