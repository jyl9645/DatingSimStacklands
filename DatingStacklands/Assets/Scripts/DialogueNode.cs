using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/DialogueNode")]
public class DialogueNode : ScriptableObject
{
    public String speaker;
    public String dialogue;
    public Sprite sprite;
    public float heart_change;
    public List<DialogueNode> responses = new List<DialogueNode>();

    public bool[] conditions;   

}
