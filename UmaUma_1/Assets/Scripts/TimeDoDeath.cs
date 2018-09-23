using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class TimeDoDeath : MonoBehaviour {
    //Variables Timer
    public static bool GameIsPaused = false;
    public GameObject gameOverMenu;
    public GameObject timerTextObject;
    public GameObject image;
    public float timer = 90f;
    private Text timerSecond;
    private Image img;
    //End Variables Timer

	// Use this for initialization
	void Start () {
        img = image.GetComponent<Image>();
        timerSecond = timerTextObject.GetComponent<Text>();
        img.enabled = false;        
	}
    
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        timerSecond.text = "Zeit: " + timer.ToString("f0");
        
        //Timer zwischen 10 und 0 timer in center
        if (timer <= 10 && timer >= 0) {
            timerSecond.alignment = TextAnchor.MiddleCenter;
            timerSecond.fontSize = 150;
            timerSecond.text = "" + timer.ToString("f0");
            
            if(timer.ToString("f0") == "10" ||
                timer.ToString("f0") == "8" || 
                timer.ToString("f0") == "6" ||
                timer.ToString("f0") == "4" ||
                timer.ToString("f0") == "2") {
            
                img.enabled = true;
            } else  {
                img.enabled = false;
            
            }
        } else if (timer <= 0) {
            //timer kleiner 0 tot 
            //show exit menu
            timerSecond.text = "";
            GameOver();

            //Hauptmenü bei ESC laden
            if (Input.GetKeyDown(KeyCode.Escape)) {
                LoadScene();
            }   
        }
	}
    
    public void LoadScene() {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver() {
        //GetComponent<camControl>.enabled = false;
        GameObject.Find("MainCamera").GetComponent<camControl>().enabled = false;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f; 
        GameIsPaused = true;
    }
}
