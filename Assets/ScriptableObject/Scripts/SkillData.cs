using UnityEngine;

[CreateAssetMenu (fileName = "SkillData", menuName = ("Skill/Data"))]
public class SkillData : ScriptableObject
{
    public Sprite icon;
    public float cooltime;
    public string skillName;
    public string skillDesc;
}