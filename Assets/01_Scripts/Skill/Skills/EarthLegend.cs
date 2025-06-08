using UnityEngine;

public class EarthLegend : ISkillBehaviour
{
    public void Execute(SkillBase skill)
    {
        ProjectileBase projectile = PoolManager.Instance.Spawn<ProjectileBase>("ProjectileBase");
        projectile.Init(skill);
    }
}