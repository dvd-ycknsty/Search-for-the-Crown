using Unity.Cinemachine;
using UnityEngine;
using Yarn.Unity;

public class NPC_Cam_Rig : MonoBehaviour
{
    //done: switch between transforms
    //done: switch between tpc to npc_c
    //done: trigger when the switch will happen by habing YnSn call the correct method
    //done: switch back from npc cam to our tpc

    public Transform npc_loc;
    public Transform pc_loc;
    public Transform pc_move_loc;
    public int pNum;
    public CinemachineCamera npc_Cam;

    [YarnCommand("cam_move")]
    public void cam_move(string locName)
    {
        npc_Cam.Priority = pNum;
        if(locName == "npc")
        {
            npc_Cam.gameObject.transform.position = npc_loc.position;
        }
        else if(locName == "pc")
        {
            npc_Cam.gameObject.transform.position = pc_loc.position;
        }
        else if(locName == "return")
        {
            npc_Cam.Priority = 0;
        }
    }

    public void movePlayer()
    {
        _GameController.instance.movePlayerOnNPC(pc_move_loc);
    }
}
