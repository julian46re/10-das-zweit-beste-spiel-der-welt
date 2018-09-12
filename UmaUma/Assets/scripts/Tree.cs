using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour {
    //Variables
    GameObject thisTree;
    GameObject childObj ;
    public int treeHealth = 5;
    private bool isFallen = false;
    Text TriggerTextCactus;
    
    private void Start() {
        thisTree = transform.parent.gameObject;
        childObj = GameObject.FindGameObjectWithTag("ShowCoconut");
        childObj.SetActive(false);
        //Debug.Log(childObj);
    }

    private void Update() {
        if(treeHealth > 0 && treeHealth < 3) {
            TriggerTextCactus = GameObject.Find("Collision Text").GetComponent<Text>();
            TriggerTextCactus.enabled = true;
            TriggerTextCactus.text = "Nochmal schlagen!";
        } else if (treeHealth == 0) {
            TriggerTextCactus.enabled = false;
        }
        
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
        childObj.SetActive(true);
    }
}
