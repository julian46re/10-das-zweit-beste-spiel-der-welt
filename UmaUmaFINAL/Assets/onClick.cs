using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class onClick : MonoBehaviour {
	
	public Button button_r;
	public Button button_b;
	public Button button_e;

	public AudioMixer audioMixer;

	void Start() {

		Button btnR = button_r.GetComponent<Button>();
		Button btnB = button_b.GetComponent<Button>();
		Button btnE = button_e.GetComponent<Button>();


		btnR.onClick.AddListener(Restart);
		btnB.onClick.AddListener(backToMain);
		btnE.onClick.AddListener(finishGame);

	}

	public void Restart() {

		FindObjectOfType<audioManager>().Play("clickButton");
		SceneManager.LoadScene("CollectScene");

	}	

	public void backToMain() {

		FindObjectOfType<audioManager>().Play("clickButton");
		SceneManager.LoadScene("MainMenu");

	}

	public void finishGame() {

		SceneManager.LoadScene("GameEnd");

	}
}
