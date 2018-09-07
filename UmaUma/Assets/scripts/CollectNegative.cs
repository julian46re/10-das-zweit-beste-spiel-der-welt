using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//#pragma strict;

//Negative Value for Collision with Cactus or Bad Coconut
public class CollectNegative : MonoBehaviour {
    int value = 10;
    
    Text TriggerTextCactus;

    void OnTriggerEnter(Collider other) {
        GameManager.instance.CollisionCactus(value, gameObject);
        //Show Message on trigger to Cactus
        TriggerTextCactus = GameObject.Find("Collision Text").GetComponent<Text>();
        TriggerTextCactus.enabled = true;
        TriggerTextCactus.text = "Ouch!!!";
    }
    
    //Remove Message by Trriger exit 
    void OnTriggerExit(Collider other) {
        TriggerTextCactus = GameObject.Find("Collision Text").GetComponent<Text>();
        TriggerTextCactus.enabled = false;
    }
    
    //Remove Text on Start scene
    void Awake(){
        TriggerTextCactus = GameObject.Find("Collision Text").GetComponent<Text>();
        TriggerTextCactus.enabled = false;
    }

}