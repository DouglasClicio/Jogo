using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public Talker talker;
    [UnityEngine.TextArea]
    public string[] messages;
}
