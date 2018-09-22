﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInteraction : MonoBehaviour {

	public float interactRadius = 3f;
	public int enemyHealth = 3;
	private bool isFallen = false;
    Text TriggerTextEnemy;
    public GameObject enemy;
    //public GameManager _GM;
    //public GameObject player;
    //private Vector3 EnemyPosition, PlayerPosition, Offset;
    //private Vector3 MaxOffset;

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, interactRadius);
	}

	private void Start() {
		enemy = transform.gameObject;
        //player = GameObject.Find("hula").transform.gameObject;
        //_GM = GameObject.Find("hula").GetComponent<GameManager>();
        //MaxOffset.Set(0.5f, 0.5f, 0.5f);
        //StartCoroutine(Damage());

	}

	private void Update() {

        //EnemyPosition = enemy.transform.position;
        //PlayerPosition = GameObject.Find("hula").transform.position;
        //Offset = EnemyPosition - PlayerPosition;

        if(enemyHealth > 0 && enemyHealth < 3) {
            TriggerTextEnemy = GameObject.Find("Collision Text").GetComponent<Text>();
            TriggerTextEnemy.enabled = true;
            TriggerTextEnemy.text = "Nochmal schlagen!";
        } else if (enemyHealth == 0) {
            TriggerTextEnemy.enabled = false;
        }
        
        if(enemyHealth <= 0 && isFallen == false) {
            Rigidbody rb = enemy.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(Vector3.forward, ForceMode.Impulse);
            StartCoroutine(destroyEnemy());
            isFallen = true;
            //SHow Coconuts from cactus
            //StartCoroutine(ShowCoconuts());
        }   
   
    }

    private IEnumerator destroyEnemy() {
        yield return new WaitForSeconds(0.5f);
        //thisTree.active = false;
        Destroy(enemy);
    }
    
    // //Timer to show coconuts from cactus
    // private IEnumerator ShowCoconuts() {
    //     yield return new WaitForSeconds(3);
    //     //InstantiateCertainPosition("Prefabs/Bad_Coconut", 1, 0.5f);
    // }

    private void DamagePlayer() {
        GameObject.Find("hula").GetComponent<GameManager>().health -= 5;
    }

    void OnTriggerEnter(Collider playerHit) {
        if (playerHit.gameObject.tag == "Player") {
            DamagePlayer();
        }
    }

    // private IEnumerator Damage() {
    //     if (Vector3.Distance(PlayerPosition, EnemyPosition) <= 0.5f) {
    //         DamagePlayer();
    //     }
    //     yield return new WaitForSeconds(1);
    // }

}
