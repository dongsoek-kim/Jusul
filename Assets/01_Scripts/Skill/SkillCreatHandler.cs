using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillCreatHandler : MonoBehaviour
{
    private static readonly Dictionary<int, float[]> gradeChancesByLevel = new()
    {
        { 1, new float[] { 74.5f, 20f, 5f, 0.5f, 0f, 0f } },
        { 2, new float[] { 62.94f, 30f, 6f, 1f, 0.05f, 0.01f } },
        { 3, new float[] { 52.85f, 37f, 8f, 2f, 0.1f, 0.05f } },
        { 4, new float[] { 43.6f, 42f, 11f, 3f, 0.3f, 0.1f } },
        { 5, new float[] { 35.2f, 45f, 15f, 4f, 0.5f, 0.3f } },
    };

    public int skillIndex;
    public int elementType;
    public int skillGrade;

    public void SkillCreat()
    {
        elementType = Random.Range(0,2);
        skillGrade = GradeCarculator();
        skillIndex= elementType * 6 + skillGrade;
    }

    public int GradeCarculator()
    {
        int summonLevel = SkillManager.Instance.summonLevel;
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
}
