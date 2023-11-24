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
    public AudioSource audioSource; // Adicionando componente de áudio

    [Header("Settings")]
    public float typingSpeed;
    private List<DialogueElement> sentences;
    private int index;

    public void Speech(Sprite p, List<DialogueElement> txt, string npcName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        npcNameText.text = npcName;
        StartCoroutine(TypeSentence());

    }

    IEnumerator TypeSentence()
    {
        npcNameText.text = sentences[index].npcName;
        profile.sprite = sentences[index].profile;
        foreach (char letter in sentences[index].speechTxt.ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Reproduz o áudio associado à sentença atual
        if (sentences[index].audioClip != null)
        {
            audioSource.clip = sentences[index].audioClip;
            audioSource.Play();
        }
    }

    public void NextSentence()
    {
        if(speechText.text == sentences[index].speechTxt)
        {
            //ainda há textos
            if(index < sentences.Count - 1)
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
