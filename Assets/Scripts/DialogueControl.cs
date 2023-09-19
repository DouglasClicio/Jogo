using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public Text speechText;
    public Text npcNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;

    public void Speech(Sprite p, string[] txt, string npcName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        npcNameText.text = npcName;
        StartCoroutine(TypeSentence());

    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            //ainda há textos
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            //lido quando acaba os textos
            else 
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
            }
        }
    }
}
