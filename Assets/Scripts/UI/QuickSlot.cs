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
    
    //Skill을 abstract클래스로 모든 스킬이 가지는 공통을 가지는 클래스로 변경

    private bool isColldown => 1 > curTime / cooltime;

    public void OnSlotClicked()
    {
        if (skill == null) return;
        if (isColldown) return;

        //Skill의 추상메서드 UseSkill을 발동
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
