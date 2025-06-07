using UnityEngine;

public class FireCommon : ISkillBehaviour
{
    public void Execute(SkillBase skill)
    {
        Debug.Log("FireCommon 발사!");
    }
}