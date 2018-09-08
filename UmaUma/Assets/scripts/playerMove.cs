using System.Collections;
using UnityEngine;

public class playerMove : MonoBehaviour {

	private float speed = 10.0f; //Bewegungsschnelligkeit
	private float jumpForce = 8.0f; //Sprungkraft
	private float gravity = 30.0f; //Anziehungskraft
	public CharacterController controller;


	private Vector3 moveDir; // Startpunkt für Bewegung

	// Use this for initialization
	void Start () {

		// Maus verschwindet bei Start, kommt mit Escape wieder
		Cursor.lockState = CursorLockMode.Locked;

		// Hinzufügen des Unity Controllers zur Spielfigur
		controller = GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () {

		/* Solange der Spieler den Boden berührt kann er die moveDir ändern und...
			...Horizontal und Vertikal laufen mit W,A,S,D 
			...misst die Veränderung der Drehung, Bewegung vom Spieler
			...Geschwindigkeit anpassen
		*/

		if (controller.isGrounded) {

			//moveDir = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDir = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
			moveDir = moveDir.normalized;

			moveDir = transform.TransformDirection (moveDir);

			moveDir *= speed;


			// Sprungkraft auf Leertaste gelegt. In Y-Richtung
			if (Input.GetButtonDown ("Jump")) {

				moveDir.y = jumpForce;

			}


		}

			/* Braucht man um die Geschwindigkeit verschiedener Rechner (FPS) auszugleichen
			da mehr Leistung zu schnelleren Bewewgungen führen würde. (FPS * Speed)
			Wird mit der Zeit verrechnet */

		moveDir.y -= gravity * Time.deltaTime;

		controller.Move (moveDir * Time.deltaTime);
		
	}
}
