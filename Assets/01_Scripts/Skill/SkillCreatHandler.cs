using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillCreatHandler
{
    private static readonly Dictionary<int, float[]> gradeChancesByLevel = new()
    {
        { 1, new float[] { 74.5f, 20f, 5f, 0.5f, 0f, 0f } },
        { 2, new float[] { 62.94f, 30f, 6f, 1f, 0.05f, 0.01f } },
        { 3, new float[] { 52.85f, 37f, 8f, 2f, 0.1f, 0.05f } },
        { 4, new float[] { 43.6f, 42f, 11f, 3f, 0.3f, 0.1f } },
        { 5, new float[] { 35.2f, 45f, 15f, 4f, 0.5f, 0.3f } },
    };

    private int skillIndex;
    private int elementType;
    private int skillGrade;

    public int RequirementMoney { get; private set; } = 20;
    public int RequirementUpgradeMoney { get; private set; } = 75; // 스킬 등급당 요구 금액 증가량
    private int maxSkillAmount = 25;

    public int SkillCreat()
    {
        elementType = Random.Range(0,2);
        skillGrade = GradeCarculator();
        skillIndex= elementType * 6 + skillGrade;
        return skillIndex;
    }

    public int GradeCarculator()
    {
        int summonLevel = SkillManager.Instance.createLevel;
        float[] chances = gradeChancesByLevel[summonLevel];

        float roll = Random.value * 100f;
        float cumulative = 0f;

        for (int i = 0; i < chances.Length; i++)
        {
            cumulative += chances[i];
            if (roll <= cumulative)
            {
                return i;
            }
        }
        return 0;
    }

    public bool CanCreat()
    {
        if (SkillManager.Instance.SkillAmount >= maxSkillAmount)
        {
            UIManager.Instance.Alarm("스킬 최대 생성량 도달");
            return false; 
        }
        if (GameManager.Instance.Money < RequirementMoney)
        {
            UIManager.Instance.Alarm("돈이 부족합니다");
            return false;
        }
        return true;
    }

    public void AddRequirementMoney()
    {
        RequirementMoney ++;
    }
    public void AddRequirementUpgradeMoney()
    {
        RequirementUpgradeMoney += 25;
    }
}
