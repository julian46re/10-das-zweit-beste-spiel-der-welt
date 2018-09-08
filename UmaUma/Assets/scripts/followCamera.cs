using System.Collections;
using UnityEngine;

public class followCamera : MonoBehaviour {

	private const float Y_ANGLE_MIN = 0.0f;
	private const float Y_ANGLE_MAX = 50.0f;

	public Transform lookAt; //Objekt, welches die Kamera anschaut
	public Transform camTransform; //Kamerabewegung

	private Camera cam; //Kamera

	private float distance = 10.0f; //Abstand der Kamera 
	private float currentX = 0.0f; //Aktueller X-Wert der Cam
	private float currentY = 0.0f; //Aktueller Y-Wert der Cam
	private float sensitivityX = 4.0f; //Empfindlichkeit X
	private float sensitivityY = 1.0f; //Empfindlichkeit Y

	private void Start() {

		camTransform = transform; 
		cam = Camera.main; //Nimmt die erste erstellte Kamera im Spiel

	}

	private void Update() {

		// Mausbewegung
		currentX += Input.GetAxis("Mouse X");
		currentY += Input.GetAxis("Mouse Y");

		// Winkelspanne der Kamera wird festgelegt
		currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

		camTransform.LookAt(lookAt.position); // Kamera verändert sich mit der Figur, schaut darauf
	}

	private void LateUpdate() {

		Vector3 dir = new Vector3(0,0,-distance);
		Quaternion rot = Quaternion.Euler(currentY, currentX, 0); //Drehung
		camTransform.position = lookAt.position + rot * dir; //Position der Kamera = Position der Figur + Drehung * Abstand

	}

}
