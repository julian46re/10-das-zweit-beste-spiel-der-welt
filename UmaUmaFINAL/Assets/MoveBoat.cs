using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoat : MonoBehaviour {

	public Rigidbody rb;
	public float moveSpeed;

	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce(-400 * Time.deltaTime, 0, moveSpeed * Time.deltaTime);
	}
}
