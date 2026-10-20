using UnityEngine;

[CreateAssetMenu(fileName = "npcData", menuName = "NPC Profile")]
public class npcData : ScriptableObject
{
    public string npcName;
    public string startingNode;
    public enum dialoguePhase { comeback, begin, quest_started, quest_completed, }
    public dialoguePhase currentPhase;

    public void dataReset()
    {
        currentPhase = dialoguePhase.begin;
    }
}
