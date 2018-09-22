using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public CharacterController controller;

	private Vector3 moveDirection;
	public float gravityScale;

	// Use this for initialization
	void Start () {
		
		controller = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
		
		//moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
		float yStore = moveDirection.y;
		moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));	
		moveDirection = moveDirection.normalized * moveSpeed;
		moveDirection.y = yStore;

		//Wenn der Spieler den Boden berührt
		if(controller.isGrounded) {

			//Springen auf Leertaste
			moveDirection.y = 0f;
			if(Input.GetButtonDown("Jump")) {

				moveDirection.y = jumpForce;

			}


			//Rennen auf left shift
			if(Input.GetButton("Sprint")) {

				moveSpeed = 25f;

			} else {

				moveSpeed = 15f;

			}

		}	
		// Nimmt aktuelle Y-position und addiert die Schwerkraft
		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);

		controller.Move(moveDirection * Time.deltaTime);

	}
}
