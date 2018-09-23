using System.Collections;
using UnityEngine;

public class camControl : MonoBehaviour {

 	float minFov = 25f;
 	float maxFov = 90f;
 	float sensitivity = 30f;

	public Transform target;
	public Vector3 offset;
	public float rotateSpeed;
	public Transform pivot;
	public float maxViewAngle;
	public float minViewAngle;
	public bool invertY;


	// Use this for initialization
	void Start () {
		
		//Abstand zwischen Kamera und Spieler (Position Figur - Position Kamera)
		offset = target.position - transform.position;
		//Pivot an Figur binden
		pivot.transform.position = target.transform.position;
		pivot.transform.parent = target.transform;
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

		//Scrollfunktion der Kamera
		if(Input.GetAxis("Mouse ScrollWheel") != 0) {

			float fov = Camera.main.fieldOfView; //Kamera Field of View einbinden
   			fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity; //Scroll und Schnelligkeit
   			fov = Mathf.Clamp(fov, minFov, maxFov); //Stellt Grenze des Scrollens
   			Camera.main.fieldOfView = fov;

		}

		//Nimm die X-Position der Maus und dreh den Spieler mit
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		target.Rotate(0, horizontal, 0);

		
		//Nimm die Y-Position der Maus und dreh den Pivot mit, damit sich die Figur nicht nach vorne und hinten neigt
		float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

		//pivot.Rotate(-vertical, 0, 0);
		if(invertY) {

			pivot.Rotate(vertical, 0, 0);

		} else {

			pivot.Rotate(-vertical, 0, 0);

		}

		//Kamerawinkel Limit
		if(pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f ) {

			pivot.rotation =  Quaternion.Euler(maxViewAngle, 0, 0);

		}

		if(pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle) {

			pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);

		}

		//Kamerabewegung an Spielerdrehung angepasst
		float desiredYAngle = target.eulerAngles.y;
		float desiredXAngle = pivot.eulerAngles.x;
		Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

		transform.position = target.position - (rotation * offset);

		if(transform.position.y < target.position.y) {

			transform.position = new Vector3(transform.position.x, target.position.y -.5f, transform.position.z);

		}

		Cursor.visible = false; //Maus ausblenden
		transform.LookAt(target); //Kamera schau Figur an

	}

}
