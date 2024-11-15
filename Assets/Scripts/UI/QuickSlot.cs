using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    [SerializeField] private Image CooltimeIndicator;
    [SerializeField] private Image SkillIcon;
    [SerializeField] private Skill skill;
    private float cooltime;
    private float curTime;
    
    //Skill�� abstractŬ������ ��� ��ų�� ������ ������ ������ Ŭ������ ����

    private bool isColldown => 1 > curTime / cooltime;

    public void OnSlotClicked()
    {
        if (skill == null) return;
        if (isColldown) return;

        //Skill�� �߻�޼��� UseSkill�� �ߵ�
        skill.UseQSkill();
        curTime = cooltime;
    }

    private void Update()
    {
        if(!isColldown) return;

        curTime -= Time.deltaTime * cooltime;
    }

    public void SkillChange(Skill newSkill)
    {
        if (isColldown) return;
        skill = newSkill;
        SkillIcon.sprite = newSkill.skilldata.icon;
        cooltime = newSkill.skilldata.cooltime;
    }
}
