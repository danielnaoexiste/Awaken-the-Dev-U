using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StateManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] State startingState;
    [SerializeField] GameObject inputs;
    [SerializeField] TextMeshProUGUI inputCode; 
    [SerializeField] GameObject choices;

    State state;
    int cont = 0;
    void Start() 
    {
        state = startingState;
        // textComponent.text = state.GetStateStory();
        StartCoroutine(TypeText(state.GetStateStory()));
        // ManageType();
    }

    public void ChangeState(int num) {
        var nextStates = state.GetNextStates();
                for(int k = 3; k >= 0; k--) {
                    choices.transform.GetChild(0).GetChild(k).transform.localScale = new Vector3(1, 1, 0);
                }
                state = nextStates[num];
                choices.SetActive(false);
                inputCode.text = "";
                cont = 0;
                inputs.SetActive(false);
                StopAllCoroutines();
                StartCoroutine(TypeText(state.GetStateStory()));
            }

    private void ManageType()
    {
        var stateType = state.GetStateType();
        if (stateType == "Choices") {
            choices.SetActive(true);
            inputs.SetActive(false);
            string[] a = state.GetChoices();
            for(int i = 0; i < state.GetChoiceSize(); i++) {
                choices.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = a[i];
            }
            
            for(int i = 3; i >= state.GetChoiceSize(); i--) {
                choices.transform.GetChild(0).GetChild(i).transform.localScale = new Vector3(0, 0, 0);
            }

        } else if (stateType == "Input") {
            choices.SetActive(false);
            inputs.SetActive(true);
        }
    }

    public void AddNumberToInputCode(int num) 
    {
        if (cont < 4) {
            inputCode.text += num.ToString();
            cont++;
            if (cont == 4) 
            {
                if (inputCode.text == state.GetInputCode()) 
                {
                    ChangeState(0);
                } else {
                    inputCode.text = "";
                    cont = 0;
                }
            }
        } 
    }

    IEnumerator TypeText(string textToDisplay) 
    {
        textComponent.text = "";
        foreach(char letter in textToDisplay.ToCharArray()) 
        {
            textComponent.text += letter;
            yield return null; 
        }
        ManageType();
        yield return null;
    }
}