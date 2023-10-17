using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class DialogueElement
{
    public string npcName;
    public Sprite profile;
    public string speechTxt;
}

public class NpcDialogue : MonoBehaviour
{
   // public string[] DialogueNpc;
   // public int dialogueIndex;
   // public GameObject dialoguePanel;
    public Sprite profile;
    public List<DialogueElement> speechTxt;
    public string npcName;
    public LayerMask playerLayer;
    public float radius;
    private DialogueControl dc;
    bool onRadius;
   // public bool readyToSpeak;
   // public bool startDialogue;

    // Start is called before the first frame update
    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Interact();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && onRadius)
        {
            dc.Speech(profile, speechTxt, npcName);
        }

    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);

        if(hit != null)
        {
            onRadius = true;
        }
        else
        {
            onRadius = false;
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
