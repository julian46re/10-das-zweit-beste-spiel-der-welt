using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TimeDoDeath : MonoBehaviour {
    //Variables Timer
    public static bool GameIsPaused = false;
    public GameObject gameOverMenu;
    public GameObject timerTextObject;
    public GameObject image;
    private float timer = 11f;
    private Text timerSecond;
    private Image img;
    //private float nextActionTime = 0.0f;
    //public int period = 2;
    //End Variables Timer
    
    private bool toggleGUI ;
    private Texture2D textureToDisplay;

	// Use this for initialization
	void Start () {
        img = image.GetComponent<Image>();
        timerSecond = timerTextObject.GetComponent<Text>();
        img.enabled = false;
        // if (timer <= 10 && timer >= 0) {
        //    StartCoroutine(showBackground());
        //}
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
            //if ((timer % 2) == 0) {
            //Debug.Log(timer);
            if(timer.ToString("f0") == "10" || timer.ToString("f0") == "8" || timer.ToString("f0") == "6" || timer.ToString("f0") == "4" || timer.ToString("f0") == "2") {
                //Debug.Log(img.enabled);
                img.enabled = true;
            } else  {
                img.enabled = false;
            
            }
        } else if (timer <= 0) {
            //timer kleiner 0 tot 
            //show exit menu
            timerSecond.text = "";
            GameOver();
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
    
    private IEnumerator showBackground() {
        img.enabled = true;
        yield return new WaitForSeconds(2);
        img.enabled = false;
    }
}
