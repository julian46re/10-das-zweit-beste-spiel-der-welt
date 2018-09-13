using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
    public GameObject scoreTextObject;
    public GameObject healthTextObject;
    
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
        scoreText = scoreTextObject.GetComponent<Text>();
        scoreText.text = "Score: " + health.ToString();

        healthText = healthTextObject.GetComponent<Text>();
        healthText.text = "Score: " + health.ToString();


    }   
    
    //Collect Coconut
    public void Collect(int passedValue, GameObject passedObject) {
        passedObject.GetComponent<Renderer>().enabled = false;
        passedObject.GetComponent<Collider>().enabled = false;
        Destroy(passedObject, 1.0f);

        score = score + passedValue;
        scoreText.text = "Score: " + score.ToString();    
    }
    
    //Collect Negative Coconut
    // - Score and - Health
    public void CollectNegativeCoconut(int passedValue, GameObject passedObject) {
        passedObject.GetComponent<Renderer>().enabled = false;
        passedObject.GetComponent<Collider>().enabled = false;
        Destroy(passedObject, 1.0f);

        score = score - passedValue;
        scoreText.text = "Score: " + score.ToString();
        health = health - passedValue;
        healthText.text = "Health: " + health.ToString();    
    }
    
    //Collision Cactus
    // - Score and - Health
    public void CollisionCactus(int passedValue, GameObject passedObject){
        score = score - passedValue;
        scoreText.text = "Score: " + score.ToString();  
        health = health - passedValue;
        healthText.text = "Health: " + health.ToString();    

    }

    void Update() {

        if (health <= 0) {

            GameOver();

        }

    }

    void GameOver () {

        if (gameHasEnded == false) {

            gameHasEnded = true;
            Debug.Log("LOOL DEAD");
            Invoke("Restart", restartDelay);

        }

    }

    void Restart () {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
