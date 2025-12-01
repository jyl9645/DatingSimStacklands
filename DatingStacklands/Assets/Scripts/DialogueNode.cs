using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/DialogueNode")]
public class DialogueNode : ScriptableObject
{
    public enum op
    {
        none,
        lessthan,
        morethan,
    }

    public String speaker;
    public op conditionOperator;
    public int condition;
    public String[] dialogue;
    public Sprite[] sprite;
    public float heart_change;
    public List<DialogueNode> responses = new List<DialogueNode>();

}
