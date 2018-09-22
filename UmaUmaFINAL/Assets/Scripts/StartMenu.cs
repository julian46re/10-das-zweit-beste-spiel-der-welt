using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public Button button_1;
	public Button button_2;
	public Button button_3;
	public GameObject mainMenu;
	public GameObject optionsMenu;

	public AudioMixer audioMixer;

	void Start() {

		Button btn1 = button_1.GetComponent<Button>();
		Button btn2 = button_2.GetComponent<Button>();
		Button btn3 = button_3.GetComponent<Button>();

		btn1.onClick.AddListener(PlayGame);
		btn2.onClick.AddListener(changeMenu);
		btn3.onClick.AddListener(QuitGame);

		optionsMenu = GameObject.Find("OptionsMenu");
		optionsMenu.active = false;
		mainMenu = GameObject.Find("MainMenu");
		mainMenu.active = true;

	}

	public void PlayGame() {

		FindObjectOfType<audioManager>().Play("clickButton");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}	

	public void changeMenu() {

		FindObjectOfType<audioManager>().Play("clickButton");
		optionsMenu.active = true;
		mainMenu.active = false;

	}

	public void QuitGame() {

		FindObjectOfType<audioManager>().Play("clickButton");
		Debug.Log("Quit");
		Application.Quit();

	}

	public void SetVolume (float volume) {

		audioMixer.SetFloat("volume", volume);

	}

}
