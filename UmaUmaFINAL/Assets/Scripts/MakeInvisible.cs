using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInvisible : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<MeshRenderer>().enabled = false;
	}
	
}
