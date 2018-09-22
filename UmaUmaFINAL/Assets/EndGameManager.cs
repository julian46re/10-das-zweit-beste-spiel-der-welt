using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Beenden());
	}
	
	

	IEnumerator Beenden() {
		yield return new WaitForSeconds(8);
		SceneManager.LoadScene("MainMenu");
	}
}
