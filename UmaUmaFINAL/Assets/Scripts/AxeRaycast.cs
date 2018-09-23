using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeRaycast : MonoBehaviour {
    //Variables
    public GameObject axe;
    private bool isEquiped = true;

    //private void Start() {
    //    axe.SetActive(false);    
    //}

    private void Update() {
        
        if(!axe.activeSelf && Input.GetKeyDown(KeyCode.Alpha1)) {
            isEquiped = true;
            axe.SetActive(true);
        } else if(Input.GetKeyDown(KeyCode.Alpha1)) {
            isEquiped = false;
            axe.SetActive(false);
        }

        //Raycast
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        //Origin, Direction, RaycastHit, Length
        if(Physics.Raycast(transform.position, fwd, out hit, 5)) {
            if(hit.collider.tag == "tree" && Input.GetMouseButtonDown(0) && isEquiped == true) {
                //Debug.Log("hit");
                Tree treeScript = hit.collider.gameObject.GetComponent<Tree>();
                treeScript.treeHealth = treeScript.treeHealth - 1;
            }
            if(hit.collider.tag == "cactus" && Input.GetMouseButtonDown(0) && isEquiped == true) {

                //Debug.Log("Cactus hit!");

                string HitObjName = hit.collider.gameObject.name;

                GameObject.Find(HitObjName).GetComponent<DestroyCactus>().cactusHealth --; 

            }

            if(hit.collider.tag == "enemy" && Input.GetMouseButtonDown(0) && isEquiped == true) {
                //Debug.Log("Enemy hit!");
                string HitObjName = hit.collider.gameObject.name;
                GameObject.Find(HitObjName).GetComponent<EnemyInteraction>().enemyHealth --;

            }
        }
    }
}
