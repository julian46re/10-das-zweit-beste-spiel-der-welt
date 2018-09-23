using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonUp(0)) {

			transform.Rotate(20f, 0, 0);

		} 
	}
}
