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
        //    Debug.Log($"Quest {i} - {quest.QuestName} (최소 레벨 {quest.QuestRequiredLevel})");
        //    i++;
        //}

        //foreach(QuestDataSO quest in Quests)
        //{
        //    int i = 1;
        //    Debug.Log($"Quest{i} - {quest.QuestName} (최소레벨 {quest.QuestRequiredLevel}");
        //    MonsterQuestDataSO monsterQuest = quest as MonsterQuestDataSO;
        //    EncounterQuestDataSO encounterQuest = quest as EncounterQuestDataSO;

        //    if(monsterQuest != null)
        //    {
        //        Debug.Log($"{monsterQuest.monster}을(를) {monsterQuest.requiredNumber}마리 소탕");
        //    }
        //    else if (encounterQuest != null)
        //    {
        //        Debug.Log($"{encounterQuest.encountNPC}와(과) 대화하기");
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    i++;
        //}

        for(int i = 0; i < Quests.Length; i++)
        {
            Debug.Log($"Quest{i + 1} - {Quests[i].QuestName} (최소레벨 {Quests[i].QuestRequiredLevel}");

            MonsterQuestDataSO monsterQuest = Quests[i] as MonsterQuestDataSO;
            EncounterQuestDataSO encounterQuest = Quests[i] as EncounterQuestDataSO;
            if (monsterQuest != null)
            {
                Debug.Log($"{monsterQuest.monster}을(를) {monsterQuest.requiredNumber}마리 소탕");
            }
            else if (encounterQuest != null)
            {
                Debug.Log($"{encounterQuest.encountNPC}와(과) 대화하기");
            }
            else
            {
                return;
            }
        }

        //for (int i = 0; i < Quests.Length; i++)
        //{
        //    Debug.Log($"Quest{i + 1} - {Quests[i].QuestName} (최소레벨 {Quests[i].QuestRequiredLevel}");

        //    if (Quests[i] is MonsterQuestDataSO)
        //    {
        //        Debug.Log($"{(Quests[i].monster}을(를) {(Quests[i].requiredNumber}마리 소탕");
        //    }
        //    else if (Quests[i] is EncounterQuestDataSO)
        //    {
        //        Debug.Log($"{Quests[i].encountNPC}와(과) 대화하기");
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}


        //부모클래스를 두어서 공통 값을 사용하여도 된다.
    }
}
