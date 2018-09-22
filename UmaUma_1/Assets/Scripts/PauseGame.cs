using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

	public Button weiter;
	public Button steuerung;
	public Button beenden;
	public Button zuruck;

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject steuMenuUI;

	public AudioMixer audioMixer;

	void Start() {

		Button btnW = weiter.GetComponent<Button>();
		Button btnS = steuerung.GetComponent<Button>();
		Button btnB = beenden.GetComponent<Button>();
		Button btnB2 = zuruck.GetComponent<Button>();

		btnW.onClick.AddListener(Resume);
		btnS.onClick.AddListener(steuMenu);
		btnB.onClick.AddListener(backToMenu);
		btnB2.onClick.AddListener(stepBack);

		pauseMenuUI = GameObject.Find("Pause Menu");
		pauseMenuUI.active = false;
		steuMenuUI = GameObject.Find("Steuerung Menu");
		steuMenuUI.active = false;

	}
	
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

		GameObject.Find("MainCamera").GetComponent<camControl>().enabled = true;
		pauseMenuUI.active = false;
		steuMenuUI.active = false;
		Time.timeScale = 1f;
		GameIsPaused = false;

	}

	public void Pause() {

		GameObject.Find("MainCamera").GetComponent<camControl>().enabled = false;
		pauseMenuUI.active = true;
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void steuMenu () {

		pauseMenuUI.active = false;
		steuMenuUI.active = true;

	}

	public void backToMenu() {

		SceneManager.LoadScene(0);

	}	

	public void stepBack() {

		pauseMenuUI.active = true;
		steuMenuUI.active = false;

	}

}

