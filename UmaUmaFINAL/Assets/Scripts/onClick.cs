using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class onClick : MonoBehaviour {
	
	public Button ende;
	public Button neustart;

	public AudioMixer audioMixer;

	void Start() {

		Button btnE = ende.GetComponent<Button>();
		Button btnN = neustart.GetComponent<Button>();

		btnE.onClick.AddListener(finishGame);
		btnN.onClick.AddListener(Restart);
	}

	public void Restart() {

		FindObjectOfType<audioManager>().Play("clickButton");
		SceneManager.LoadScene(2);

	}	

	public void finishGame() {

		FindObjectOfType<audioManager>().Play("clickButton");
		SceneManager.LoadScene(4);

	}
}
