using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class onClickTwo : MonoBehaviour {
	
	public Button quit;
	public Button nochmal;

	public AudioMixer audioMixer;

	void Start() {

		Button btnQ = quit.GetComponent<Button>();
		Button btnA = nochmal.GetComponent<Button>();

		btnQ.onClick.AddListener(Beenden);
		btnA.onClick.AddListener(Restart);
	}

	public void Restart() {

		FindObjectOfType<audioManager>().Play("clickButton");
		SceneManager.LoadScene(2);

	}	

	public void Beenden() {

		FindObjectOfType<audioManager>().Play("clickButton");
		SceneManager.LoadScene(0);

	}
}
