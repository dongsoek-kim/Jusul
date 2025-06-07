using UnityEngine;

public class WaterHero : ISkillBehaviour
{
    public void Execute(SkillBase skill)
    {
        Debug.Log("WaterHero 발사!");
    }
}