//퀘스트이름, 필요레벨, NPC, 선행퀘스트
//잡아야하는 몬스터의 이름, 목표치

using UnityEngine;

public enum Monster
{
    Skeleton,
    Goblin
}

[CreateAssetMenu(fileName = "DefaultMonsterQuestDataSO", menuName = "QuestDataSO/MonsterQuestDataSO", order = 1)]
public class MonsterQuestDataSO : QuestDataSO
{
    public Monster monster;
    public int requiredNumber;
}
