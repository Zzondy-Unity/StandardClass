using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] QuestDataSO[] Quests;


    private static QuestManager instance;

    public static QuestManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<QuestManager>();
                if(instance == null)
                {
                    GameObject go = new GameObject("QuestManager");
                    go.AddComponent<QuestManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        //foreach(QuestDataSO quest in Quests)
        //{
        //    int i = 1;
        //    Debug.Log($"Quest {i} - {quest.QuestName} (�ּ� ���� {quest.QuestRequiredLevel})");
        //    i++;
        //}

        //foreach(QuestDataSO quest in Quests)
        //{
        //    int i = 1;
        //    Debug.Log($"Quest{i} - {quest.QuestName} (�ּҷ��� {quest.QuestRequiredLevel}");
        //    MonsterQuestDataSO monsterQuest = quest as MonsterQuestDataSO;
        //    EncounterQuestDataSO encounterQuest = quest as EncounterQuestDataSO;

        //    if(monsterQuest != null)
        //    {
        //        Debug.Log($"{monsterQuest.monster}��(��) {monsterQuest.requiredNumber}���� ����");
        //    }
        //    else if (encounterQuest != null)
        //    {
        //        Debug.Log($"{encounterQuest.encountNPC}��(��) ��ȭ�ϱ�");
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    i++;
        //}

        for(int i = 0; i < Quests.Length; i++)
        {
            Debug.Log($"Quest{i + 1} - {Quests[i].QuestName} (�ּҷ��� {Quests[i].QuestRequiredLevel}");

            MonsterQuestDataSO monsterQuest = Quests[i] as MonsterQuestDataSO;
            EncounterQuestDataSO encounterQuest = Quests[i] as EncounterQuestDataSO;
            if (monsterQuest != null)
            {
                Debug.Log($"{monsterQuest.monster}��(��) {monsterQuest.requiredNumber}���� ����");
            }
            else if (encounterQuest != null)
            {
                Debug.Log($"{encounterQuest.encountNPC}��(��) ��ȭ�ϱ�");
            }
            else
            {
                return;
            }
        }

        //for (int i = 0; i < Quests.Length; i++)
        //{
        //    Debug.Log($"Quest{i + 1} - {Quests[i].QuestName} (�ּҷ��� {Quests[i].QuestRequiredLevel}");

        //    if (Quests[i] is MonsterQuestDataSO)
        //    {
        //        Debug.Log($"{(Quests[i].monster}��(��) {(Quests[i].requiredNumber}���� ����");
        //    }
        //    else if (Quests[i] is EncounterQuestDataSO)
        //    {
        //        Debug.Log($"{Quests[i].encountNPC}��(��) ��ȭ�ϱ�");
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}


        //�θ�Ŭ������ �ξ ���� ���� ����Ͽ��� �ȴ�.
    }
}
