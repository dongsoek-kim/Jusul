using UnityEngine;

public class EnemyBase : MonoBehaviour , IPoolable
{
    public float Hp = 100f;
    public float Damage = 10f;
    public float Speed = 2f;
    public float AttackCooldown = 1f;
    public int dropMoney;

    [Header("Spawn")]
    [SerializeField]private Vector3 spawnPosition;
    [SerializeField]private Vector3 targetPosition;
    protected EnemyState state = EnemyState.Move;

    public virtual void Init()
    {

        spawnPosition = new Vector3(0, -5f, 0);
        targetPosition = new Vector3(0, 3.5f, 0); 
        transform.position = spawnPosition;
        Hp = 100+(100*GameManager.Instance.CurrentWave);
        state = EnemyState.Move;
        gameObject.SetActive(true);
    }

    protected virtual void Update()
    {
        if (state == EnemyState.Move)
        {
            MoveToTarget();
        }
        else if (state == EnemyState.Attack)
        {
            if (Time.time >= AttackCooldown)
            {
                Attack();
                AttackCooldown = Time.time + 1f; // Reset cooldown
            }
        }
    }

    protected void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up, Speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {

            state = EnemyState.Attack;
        }
    }


    public virtual void OnSpawn()
    {
        Init();
    }
    public virtual void OnDespawn()
    {
    }

    public void Attack()
    {
        GameManager.Instance.player.TakeDamage(Damage);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"Enemy took {damage} damage. Remaining HP: {Hp - damage}");
        Hp -= damage;
        if (Hp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        PoolManager.Instance.Despawn(this);
    }
}
