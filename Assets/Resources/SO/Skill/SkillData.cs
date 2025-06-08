using System;
using UnityEngine;
[Serializable]
[CreateAssetMenu(menuName = "Skill/SkillData")]
public class SkillData : ScriptableObject
{
    public Skill skillEnum;
    public SkillGrade grade;
    public int attackPower;
    public float range;
    public float cooldown;
    public ElementType elementType;

    public string description;

    public GameObject projectilePrefab;

    [NonSerialized]
    public ISkillBehaviour behaviour;
}