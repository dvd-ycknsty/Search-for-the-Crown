using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class questInteract : MonoBehaviour
{
    // TODO:set the storydata phase for yarnspinner to interpret
    // yay: impliment trigger for player to interact 
    // todo: interact button
    public TextMeshProUGUI interactText;
    public bool canInteract;
    public updateDialoguePhase changePhase;
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            setText("Press E");
            canInteract = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            setText("");
            canInteract = false;
        }
    }

    public void setText(string txt)
    {
        //set the text of a tmpro variable to the argument of this method
        interactText.text = txt;
    }

    public void Update()
    {
        if (canInteract)
        {
            if((Keyboard.current.eKey.wasPressedThisFrame))
            {
                changePhase.Invoke("quest_completed");
                canInteract = false;
            }
        }
    }
}

[System.Serializable]
public class updateDialoguePhase : UnityEvent<string>
{

}
