//퀘스트이름, 필요레벨, NPC, 선행퀘스트
//만나야하는 NPC,

using UnityEngine;

[CreateAssetMenu(fileName = "DefaultMonsterQuestDataSO", menuName = "QuestDataSO/EncounterQuestDataSO", order = 2)]
public class EncounterQuestDataSO : QuestDataSO
{
    public int encountNPC;
}