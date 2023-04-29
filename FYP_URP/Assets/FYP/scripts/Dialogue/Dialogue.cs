using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public string[] dialoguerName;
    public string[] dialoguerSentences;
    public string[] dialoguerEmotion;
    public int[] loadDialogueNo;
}
