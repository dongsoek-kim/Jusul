using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/SkillData")]
public class SkillData : ScriptableObject
{
    public Skill skillEnum;
    public SkillGrade grade;
    public int attackPower;
    public float range;
    public float cooldown;
    public ElementType elementType;
    public GameObject projectilePrefab;

    [NonSerialized]
    public ISkillBehaviour behaviour;
}