using System.Collections.Generic;
using UnityEngine;

public class NPCData : MonoBehaviour
{
    public int NPCId;
    public bool isNPC;
}

public enum NPCs
{
    HanManager = 0,
    AManager,
    BManager,
    ATutor = 2000,
    Astudent = 3000
}

