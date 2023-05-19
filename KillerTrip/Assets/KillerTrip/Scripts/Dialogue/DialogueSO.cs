using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DialogueSection
{
    public GameObject _soModel;
    public string _soName;

    [TextArea(2,5)]
    public string _soDialogue;
} 

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class DialogueSO : ScriptableObject
{
    public DialogueSection[] _dialogueSections;
}
