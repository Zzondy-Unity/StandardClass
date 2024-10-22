using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "DefaultQuestDataSO", menuName = "QuestDataSO", order = 0)]

public class QuestDataSO : ScriptableObject
{
    public string QuestName;
    public int QuestRequiredLevel;
    public int QuestNPC;
    public List<int> QuestPrerequisites;
}
//퀘스트이름, 필요레벨, NPC, 선행퀘스트