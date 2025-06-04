using UnityEngine;

public class BossMonster : EnemyBase
{
    protected override void OnEnterAttackState()
    {
        Debug.Log("Boss entered attack state");
    }

    protected override void OnAttack()
    {
        // Boss specific attack logic
        Debug.Log("Boss attacking with damage: " + Damage);
    }
}
