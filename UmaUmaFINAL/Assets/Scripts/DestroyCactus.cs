using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyCactus : MonoBehaviour {

    public Terrain WorldTerrain;
    public LayerMask TerrainLayer;

    public int cactusHealth = 5;
    private bool isFallen = false;
    Text TriggerTextCactus;
    public GameObject cactus;
    
    private void Start() {

        //Zuweisungen
    	cactus = transform.gameObject;
        WorldTerrain = GameObject.Find("WorldMap").GetComponent<Terrain>();
        TerrainLayer = 1;
        gameObject.tag = "cactus";

    }

    private void Update() {

        // if(cactusHealth > 0 && cactusHealth < 3) {
        //     TriggerTextCactus = GameObject.Find("Collision Text").GetComponent<Text>();
        //     TriggerTextCactus.enabled = true;
        //     TriggerTextCactus.text = "Nochmal schlagen!";
        // } else if (cactusHealth == 0) {
        //     TriggerTextCactus.enabled = false;
        // }
        
        if(cactusHealth <= 0 && isFallen == false) {
            Rigidbody rb = cactus.AddComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(Vector3.forward, ForceMode.Impulse);
            StartCoroutine(destroyCactus());
            isFallen = true;
            StartCoroutine(ShowCoconuts());
        }   
   
    }

    //Funtion zerstört Kaktus nach 5s
    private IEnumerator destroyCactus() {

        yield return new WaitForSeconds(5);
        Destroy(cactus);

    }
    
    //Funktion spawnt 1 schlechte Kokosnuss nach 2s
    private IEnumerator ShowCoconuts() {

        yield return new WaitForSeconds(2);
        InstantiateCertainPosition("Prefabs/Bad_Coconut", 1, 0.5f);

    }


    //Funktion setzt Spawn-Position für Objekt in bestimmtem Abstand zum Kaktus
    public void InstantiateCertainPosition(string Resource, int Amount, float AddedHeight) {

        var i = 0;
        float terrainHeight = 0f;
        RaycastHit hit;
        float randomPositionX, randomPositionY, randomPositionZ;
        Vector3 randomPosition = Vector3.zero;

        do {
            i++;
            randomPositionX = Random.Range (transform.position.x - 2f, transform.position.x + 2f);
            randomPositionZ = Random.Range (transform.position.z - 2f, transform.position.z + 2f);

            if (Physics.Raycast(new Vector3(randomPositionX, 9999f, randomPositionZ), Vector3.down, out hit, Mathf.Infinity, TerrainLayer)) {
                terrainHeight = hit.point.y;
            }

            if (hit.point.y < 1) {
                terrainHeight = -100;
            }

            randomPositionY = terrainHeight + AddedHeight;

            randomPosition = new Vector3(randomPositionX, randomPositionY, randomPositionZ);

            Instantiate(Resources.Load (Resource, typeof(GameObject)), randomPosition, Quaternion.identity);

        } while (i < Amount);

    }

}
