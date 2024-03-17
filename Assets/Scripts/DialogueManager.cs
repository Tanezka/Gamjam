using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueNameText, dialogueSentenceText;
    public Queue<string> sentencesQueue = new Queue<string>();
    public GameObject startGame;

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueNameText.text = dialogue.dialogueName;
        sentencesQueue.Clear();
        foreach (string sentence in dialogue.sentences)
            sentencesQueue.Enqueue(sentence);
        DisplayNextSentence();

    }
    public void DisplayNextSentence()
    {
        if(sentencesQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentencesQueue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    public IEnumerator TypeSentence(string text)
    {
        dialogueSentenceText.text = "";
        foreach (char character in text.ToCharArray())
        {
            dialogueSentenceText.text +=character;
            yield return new WaitForFixedUpdate();
        }
    }
    public void EndDialogue()
    {
        dialogueSentenceText.text="";

        startGame.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
}
