using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
    public GameObject scoreTextObject;

    public WorldMap WorldGenerator;
    
    public int score;
    Text scoreText;

    //Function for begin of game
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != null) {
            Destroy(gameObject);
        }
        
        //Show begin score
        scoreText = scoreTextObject.GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();
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
    public void CollectNegativeCoconut(int passedValue, GameObject passedObject) {
        passedObject.GetComponent<Renderer>().enabled = false;
        passedObject.GetComponent<Collider>().enabled = false;
        Destroy(passedObject, 1.0f);

        score = score - passedValue;
        scoreText.text = "Score: " + score.ToString();    
    }
    
    // 
    public void CollisionCactus(int passedValue, GameObject passedObject){
        score = score - passedValue;
        scoreText.text = "Score: " + score.ToString();  
    }

}
