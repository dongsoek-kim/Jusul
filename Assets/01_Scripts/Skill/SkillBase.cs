using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    void Active();
    void Deactive();
}
public class SkillBase : MonoBehaviour, ISkill
{
    [Header("스킬데이터")]
    public Skill skillName;
    public SkillGrade skillGrade;
    public ElementType elementType;
    public int attackPower;
    public int stack;
    public float cooldown;
    public float timer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public virtual void Active()
    {
        Debug.Log("Skill Activated");
    }

    public virtual void Deactive()
    {
        Debug.Log("Skill Deactivated");
    }
}
