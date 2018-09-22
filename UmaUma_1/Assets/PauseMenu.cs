using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;

	public Button weiter;
	public Button steuerung;
	public Button beenden;

	public GameObject pauseMenuUI;

	public AudioMixer audioMixer;
	
	// Update is called once per frame
	void Start () {

		Button btnW = weiter.GetComponent<Button>();
		Button btnS = steuerung.GetComponent<Button>();
		Button btnB = beenden.GetComponent<Button>();

		btnW.onClick.AddListener(backToGame);
		//btnS.onClick.AddListener(steuMenu);
		btnB.onClick.AddListener(backToMenu);

	}

	public void backToGame() {

		FindObjectOfType<audioManager>().Play("clickButton");
		GameObject.Find("MainCamera").GetComponent<camControl>().enabled = true;
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;

	}

	//public void steuMenu() {



	//}

	public void backToMenu() {

		FindObjectOfType<audioManager>().Play("clickButton");
		SceneManager.LoadScene(0);

	}	
}
