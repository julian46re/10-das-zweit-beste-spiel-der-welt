using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectUI : MonoBehaviour {

	public GameObject uiPrefab;
	public Transform target;

	Transform ui;
	Image healthslider;
	Transform cam;

	public int cactusHealth, palmehealth;
	public float cactusMax, palmeMax;
	public GameObject enemy;

	//public float radius = 10f;
	//Transform player;

	// Use this for initialization
	void Start () {
		cactusMax = GetComponent<DestroyCactus>().cactusHealth;
		palmeMax = GetComponent<Tree>().treeHealth;

		cam = Camera.main.transform;
		foreach (Canvas C in FindObjectsOfType<Canvas>()) {
			if (C.renderMode == RenderMode.WorldSpace) {
				ui = Instantiate(uiPrefab, C.transform).transform;
				healthslider = ui.GetChild(0).GetComponent<Image>();

				break;
			}
		}
		//player = PlayerManager.instance.player.transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		ui.position = target.position;
		ui.forward = -cam.forward;
	}

	void Update () {
		cactusHealth = GetComponent<DestroyCactus>().cactusHealth;
		palmehealth = GetComponent<Tree>().treeHealth;
		
		//Debug.Log(enemyHealth);

		UpdateHealthBar();

		//float distance = Vector3.Distance(player.position, transform.position);

		if (cactusHealth != cactusMax || palmehealth != palmeMax) {
			ui.gameObject.SetActive(true);
		} else {
			ui.gameObject.SetActive(false);
		}

		if (cactusHealth <= 0 || palmehealth <= 0) {
			ui.gameObject.SetActive(false);
		}
	}


	private void UpdateHealthBar() {
		float ratioCactus = cactusHealth / cactusMax;
		healthslider.rectTransform.localScale = new Vector3(ratioCactus, 1, 1);

		float ratioPalme = palmehealth / palmeMax;
		healthslider.rectTransform.localScale = new Vector3(ratioPalme, 1, 1);
	}

}
