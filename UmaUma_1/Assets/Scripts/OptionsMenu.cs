using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public Button button_b;

	public GameObject mainMenu;
	public GameObject optionsMenu;

	public AudioMixer audioMixer;

	void Start() {

		Button btnB = button_b.GetComponent<Button>();


		btnB.onClick.AddListener(changeMenuBack);

	}

	public void changeMenuBack() {

		FindObjectOfType<audioManager>().Play("clickButton");
		optionsMenu.active = false;
		mainMenu.active = true;

	}	

}
