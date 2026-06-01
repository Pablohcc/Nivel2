using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public Text nameText;
	public Text DialogoText;


	private Queue<string> sentences;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		sentences = new Queue<string>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void StarDialogue(Dialogue dialogue)
	{
		nameText.text = dialogue.name;
		//DialogoText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
	}


	public void DisplayNextSentences()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		Debug.Log(sentence);

		DialogoText.text = sentence;
	}


	public void EndDialogue()
	{
		Debug.Log("Conversacion Terminada");
	}
}