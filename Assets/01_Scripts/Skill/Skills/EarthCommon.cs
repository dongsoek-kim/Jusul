using UnityEngine;

public class EarthCommon : ISkillBehaviour
{
    public void Execute(SkillBase skill)
    {
        Debug.Log("EarthCommon 발사!");
    }
}