using UnityEngine;

public class EarthHero : ISkillBehaviour
{
    public void Execute(SkillBase skill)
    {
        Debug.Log("EarthHero 발사!");
    }
}