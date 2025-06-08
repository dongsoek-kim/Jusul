using UnityEngine;

public class EarthMythic : ISkillBehaviour
{
    public void Execute(SkillBase skill)
    {
        ProjectileBase projectile = PoolManager.Instance.Spawn<ProjectileBase>("ProjectileBase");
        projectile.Init(skill);
    }
}