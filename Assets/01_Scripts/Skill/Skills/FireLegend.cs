using UnityEngine;

public class FireLegend : ISkillBehaviour
{
    public void Execute(SkillBase skill)
    {
        Debug.Log("FireLegend 발사!");
    }
}