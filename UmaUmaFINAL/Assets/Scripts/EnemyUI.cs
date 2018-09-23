using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour {

	public GameObject uiPrefab;
	public Transform target;

	Transform ui;
	Image healthslider;
	Transform cam;

	public int enemyHealth;
	public float eHealthMax = 3f;
	public GameObject enemy;

	public float radius = 10f;
	Transform player;

	// Use this for initialization
	void Start () {
		cam = Camera.main.transform;
		foreach (Canvas C in FindObjectsOfType<Canvas>()) {
			if (C.renderMode == RenderMode.WorldSpace) {
				ui = Instantiate(uiPrefab, C.transform).transform;
				healthslider = ui.GetChild(0).GetComponent<Image>();

				break;
			}
		}
		player = PlayerManager.instance.player.transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		ui.position = target.position;
		ui.forward = -cam.forward;
	}

	void Update () {
		enemyHealth = GetComponent<EnemyInteraction>().enemyHealth;
		
		Debug.Log(enemyHealth);

		UpdateEnemyHealthBar();

		float distance = Vector3.Distance(player.position, transform.position);

		if (distance <= radius) {
			ui.gameObject.SetActive(true);
		} else {
			ui.gameObject.SetActive(false);
		}

		if (enemyHealth <= 0) {
			ui.gameObject.SetActive(false);
		}
	}


	private void UpdateEnemyHealthBar() {
		float ratio = enemyHealth / eHealthMax;
		healthslider.rectTransform.localScale = new Vector3(ratio, 1, 1);
	}

}
