using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour 
{
    public Text messageText;

    public void StartDialogue (Dialogue dialogue)
    {
        StopAllCoroutines();
		StartCoroutine(TypeSentence(dialogue.sentences[0]));
    }

    IEnumerator TypeSentence (string sentence)
	{
		messageText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			messageText.text += letter;
            yield return new WaitForSeconds(0.02F);
		}
	}
}