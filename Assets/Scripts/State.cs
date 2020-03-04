using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    public string type;
    public string inputCode;
    public string[] choices;
    [TextArea(10,14)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    

    public string GetStateStory()
    {
        return storyText;
    }

    public string GetStateType() 
    {
        return type;
    }
    public State[] GetNextStates()
    {
        return nextStates;
    }

    public int GetChoiceSize() 
    {
        return choices.Length;
    }

    public string[] GetChoices() {
        return choices;
    }

    public string GetInputCode() {
        return inputCode;
    }
}