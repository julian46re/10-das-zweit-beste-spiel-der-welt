using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

	public Text weiterText;
	public Text triggerText;
	public Text dialogueText;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		
		sentences = new Queue<string>();

	}

	public void StartDialogue(Dialogue dialogue) {

        weiterText.text = "Weiter";
        triggerText.text = "";

		sentences.Clear();

		foreach (string sentence in dialogue.sentences) {

			sentences.Enqueue(sentence);

		}

		DisplayNextSentence();
	}	

	public void DisplayNextSentence () {

		if (sentences.Count == 0) {

			EndDialogue();
			return;

		}

		string sentence = sentences.Dequeue();
		dialogueText.text = sentence;

	}

	void EndDialogue() {

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}
	

}