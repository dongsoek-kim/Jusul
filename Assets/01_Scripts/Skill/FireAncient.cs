using UnityEngine;

public class FireAncient : ISkillBehaviour
{
    public void Execute(SkillBase skill)
    {
        Debug.Log("FireAncient 발사!");
    }
}