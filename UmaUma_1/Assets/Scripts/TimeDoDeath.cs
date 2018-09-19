using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDoDeath : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject gameOverMenu;
    public GameObject timerTextObject;
    private float timer = 11f;
    private Text timerSecond;
    
    
 

	// Use this for initialization
	void Start () {
        timerSecond = timerTextObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        timerSecond.text = "Zeit: " + timer.ToString("f0");
        
        if (timer <= 10 && timer >= 0) {
            //RectTransform assign_text = timerSecond.GetComponent<RectTransform>();
            //assign_text.position = new Vector2(207.5f, 218.5f);
            timerSecond.alignment = TextAnchor.MiddleCenter;
            timerSecond.fontSize = 150;
            //assign_text.sizeDelta = new Vector2(100f, 300f);
            timerSecond.text = "" + timer.ToString("f0");
        } else if (timer <= 0) {
            timerSecond.text = "";
            GameOver();
            //Debug.Log(timer);
        }
	}

  public void GameOver() {
        //GetComponent<camControl>.enabled = false;
        GameObject.Find("MainCamera").GetComponent<camControl>().enabled = false;
        // Ändern auf anderes Menu
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f; 
        GameIsPaused = true;
    }
}
