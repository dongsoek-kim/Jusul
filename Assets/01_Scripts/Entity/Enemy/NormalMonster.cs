using UnityEngine;

public class NormalMonster : EnemyBase
{

    public override void Init()
    {
        base.Init();
        dropMoney = 10;
    }
    public override void OnSpawn()
    {
        base.OnSpawn();
    }
    public override void OnDespawn()
    {
        base.OnDespawn();
    }

    protected override void Die()
    {
        base.Die();
        GameManager.Instance.AddMoney(dropMoney);

        Debug.Log("NormalMonster has died.");
    }
}
