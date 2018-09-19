using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInteraction : MonoBehaviour {

	public float interactRadius = 3f;
	public int enemyHealth = 3;
	private bool isFallen = false;
    Text TriggerTextEnemy;
    public GameObject enemy;

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, interactRadius);
	}

	private void Start() {
		enemy = transform.gameObject;
	}

	private void Update() {
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
            StartCoroutine(ShowCoconuts());
        }   
   
    }

    private IEnumerator destroyEnemy() {
        yield return new WaitForSeconds(2);
        //thisTree.active = false;
        Destroy(enemy);
    }
    
    //Timer to show coconuts from cactus
    private IEnumerator ShowCoconuts() {
        yield return new WaitForSeconds(3);
        //InstantiateCertainPosition("Prefabs/Bad_Coconut", 1, 0.5f);
    }
}
