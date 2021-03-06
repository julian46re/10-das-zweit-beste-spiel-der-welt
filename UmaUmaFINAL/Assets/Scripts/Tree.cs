﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour {
    //Variables
    public Terrain WorldTerrain;
    public LayerMask TerrainLayer;
    
    GameObject thisTree;
    public int treeHealth = 5;
    private bool isFallen = false;
    Text TriggerTextCactus;
    
    private void Start() {
        thisTree = transform.parent.gameObject;
        WorldTerrain = GameObject.Find("WorldMap").GetComponent<Terrain>();
        TerrainLayer = 1;
        gameObject.tag = "tree";
    }

    private void Update() {
        // if(treeHealth > 0 && treeHealth < 3) {
        //     TriggerTextCactus = GameObject.Find("Collision Text").GetComponent<Text>();
        //     TriggerTextCactus.enabled = true;
        //     TriggerTextCactus.text = "Nochmal schlagen!";
        // } else if (treeHealth == 0) {
        //     TriggerTextCactus.enabled = false;
        // }
        
        if(treeHealth <= 0 && isFallen == false) {
            Rigidbody rb = thisTree.AddComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(Vector3.forward, ForceMode.Impulse);
            StartCoroutine(destroyTree());
            isFallen = true;
            //SHow Coconuts from tree
            StartCoroutine(ShowCoconuts());
        }   
    }

    private IEnumerator destroyTree() {
        yield return new WaitForSeconds(5);
        //thisTree.active = false;
        Destroy(thisTree);
    }
    
    //Timer to show coconuts from tree
    private IEnumerator ShowCoconuts() {
        yield return new WaitForSeconds(3);
        InstantiateCertainPosition("Prefabs/Good_Coconut", 5, 0.5f);
    }


    public void InstantiateCertainPosition(string Resource, int Amount, float AddedHeight) {

        var i = 0;
        float terrainHeight = 0f;
        RaycastHit hit;
        float randomPositionX, randomPositionY, randomPositionZ;
        Vector3 randomPosition = Vector3.zero;

        do {
            i++;
            randomPositionX = Random.Range (transform.position.x - 2f, transform.position.x + 2f);
            randomPositionZ = Random.Range (transform.position.z - 7f, transform.position.z - 3f);

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
