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


	private void Start() {

		enemy = transform.gameObject;

	}

	private void Update() {

        if(enemyHealth <= 0 && isFallen == false) {
            Rigidbody rb = enemy.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(Vector3.forward, ForceMode.Impulse);
            StartCoroutine(destroyEnemy());
            isFallen = true;
        }   
   
    }

    //Funktion zerstört Enemy nach 0.5s
    private IEnumerator destroyEnemy() {

        yield return new WaitForSeconds(0.5f);
        Destroy(enemy);

    }
    
    //Funktion zieht dem Player 5 Leben ab
    private void DamagePlayer() {

        GameObject.Find("hula").GetComponent<GameManager>().health -= 5;

    }

    //Funktion ruft bei Berührung zwischen Player und Enemy "DamagePlayer()" auf
    void OnTriggerEnter(Collider playerHit) {

        if (playerHit.gameObject.tag == "Player") {
            DamagePlayer();
        }

    }

    //Funktion zeichnet WireSphere
    void OnDrawGizmosSelected () {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);

    }

}
