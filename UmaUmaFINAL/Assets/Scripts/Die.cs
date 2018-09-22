using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {

	public GameObject gameOverMenu;
	public int health;

	
	// Update is called once per frame
	void Update () {
		health = GameObject.Find("hula").GetComponent<GameManager>().health;

		if (health == 0) {
			GameOver();
		}
		
	}

	public void GameOver() {
        //GetComponent<camControl>.enabled = false;
        GameObject.Find("MainCamera").GetComponent<camControl>().enabled = false;
        // Ändern auf anderes Menu
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f; 
    }
}
