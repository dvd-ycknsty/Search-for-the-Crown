using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class NPC_Interact : MonoBehaviour
{
    //1-get story data to set the phase of our phase of our YnSn scripts
    //2-

    public TextMeshProUGUI promtText;
    public string interactText;
    public bool canInteract;
    public DialogueRunner npcDialogue;
    public NPC_Cam_Rig npc_camRig;
    public npcData storyData;

    public void Start()
    {
        //Setting this var looks a bit static for our design taste
        //but we can practice a bit of deliberate discernment/design
        //bc we know we're creating a systematized NPC rig and interaction for multiple instances.
        //npc_camRig = transform.GetComponentInChildren<NPC_Cam_Rig>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            setText(interactText);
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
        promtText.text = txt;
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("Start NPC Dialogue");
                setText("");
                //npc_camRig.movePlayer();
                npcDialogue.StartDialogue(storyData.startingNode);
                canInteract = false;
            }
        }
    }

    [YarnCommand ("setPhase")]
    public void setStoryPhase()
    {
        InMemoryVariableStorage vStore = GameObject.FindAnyObjectByType<InMemoryVariableStorage>();
        vStore.SetValue("$dialoguePhase", storyData.currentPhase.ToString()); vStore.SetValue("$dlgPhase", storyData.currentPhase.ToString());
    }

    [YarnCommand ("getPhase")]
    public void getStoryPhase(string phase)
    {
        if (phase == "")
        {
            storyData.currentPhase = npcData.dialoguePhase.comeback;
        }
        else if (phase == "quest_started")
        {
            storyData.currentPhase = npcData.dialoguePhase.quest_started;
        }
        else if (phase == "quest_Completed")
        {
            storyData.currentPhase = npcData.dialoguePhase.quest_completed;
        }
        else
        {
            Debug.LogError("The string you passed in the yarn spinner script does not match any current dialoguePhase on the npcData scripyable.");
        }
    }

    public void OnApplicationQuit()
    {
        storyData.dataReset();
    }

}
