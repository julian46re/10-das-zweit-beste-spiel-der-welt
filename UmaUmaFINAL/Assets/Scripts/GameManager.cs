using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
    public GameObject scoreTextObject;
    public GameObject healthTextObject;
    public GameObject gameOverMenu;
    public GameObject winMenu;
    
    public int score;
    public int health;
    Text scoreText;
    Text healthText;

    bool gameHasEnded = false;
    public float restartDelay = 1f;

    //Function for begin of game
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != null) {
            Destroy(gameObject);
        }
        
        //Show begin score
        // scoreText = scoreTextObject.GetComponent<Text>();
        // scoreText.text = "Score: " + score.ToString();

        // healthText = healthTextObject.GetComponent<Text>();
        // healthText.text = "Score: " + health.ToString();
    }   

    void Update() {
        if (score <= 0) {
            score = 0;
        }
        
        if (health == 0) {
            GameObject.Find("MainCamera").GetComponent<camControl>().enabled = false;
            // Ändern auf anderes Menu
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f; 

            if (Input.GetKeyDown(KeyCode.Escape)) {
                SceneManager.LoadScene("MainMenu");
            }
            Cursor.visible = true;
        }

        if (score == 200) {
            GameObject.Find("MainCamera").GetComponent<camControl>().enabled = false;
            // Ändern auf anderes Menu
            winMenu.SetActive(true);
            Time.timeScale = 0f; 
            Cursor.visible = true;
        }
    }
    
    //Collect Coconut
    public void Collect(int passedValue, GameObject passedObject) {
        passedObject.GetComponent<Renderer>().enabled = false;
        passedObject.GetComponent<Collider>().enabled = false;
        Destroy(passedObject, 1.0f);

        score = score + passedValue;
        // scoreText.text = "Score: " + score.ToString();    
    }
    
    //Collect Negative Coconut
    public void CollectNegativeCoconut(int passedValue, GameObject passedObject) {
        passedObject.GetComponent<Renderer>().enabled = false;
        passedObject.GetComponent<Collider>().enabled = false;
        Destroy(passedObject, 1.0f);

        score = score - passedValue;
        // scoreText.text = "Score: " + score.ToString();
        //health = health - passedValue;
        //healthText.text = "Health: " + health.ToString();    
    }
    
    //Collision Cactus
    public void CollisionCactus(int passedValue, GameObject passedObject){
        //score = score - passedValue;
        //scoreText.text = "Score: " + score.ToString();  
        health = health - passedValue;
        // healthText.text = "Health: " + health.ToString();    

    }

    public void CollisionEnemy(int passedValue, GameObject passedObject) {
        health = health - passedValue;
        // healthText.text = "Health: " + health.ToString();
    }

}
