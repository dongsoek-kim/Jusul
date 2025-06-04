using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    [Header("Prefabs")]
    public BossMonster bossPrefab;
    public NormalMonster normalPrefab;

    [Header("Initial Counts")]
    public int bossCount = 2;
    public int normalCount = 5;

    private Queue<BossMonster> bossPool = new Queue<BossMonster>();
    private Queue<NormalMonster> normalPool = new Queue<NormalMonster>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < bossCount; i++)
        {
            var boss = Instantiate(bossPrefab, transform);
            boss.gameObject.SetActive(false);
            bossPool.Enqueue(boss);
        }

        for (int i = 0; i < normalCount; i++)
        {
            var normal = Instantiate(normalPrefab, transform);
            normal.gameObject.SetActive(false);
            normalPool.Enqueue(normal);
        }
    }

    public BossMonster GetBoss()
    {
        if (bossPool.Count == 0)
        {
            var boss = Instantiate(bossPrefab, transform);
            boss.gameObject.SetActive(false);
            bossPool.Enqueue(boss);
        }
        var obj = bossPool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public NormalMonster GetNormal()
    {
        if (normalPool.Count == 0)
        {
            var normal = Instantiate(normalPrefab, transform);
            normal.gameObject.SetActive(false);
            normalPool.Enqueue(normal);
        }
        var obj = normalPool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void ReleaseBoss(BossMonster boss)
    {
        boss.gameObject.SetActive(false);
        bossPool.Enqueue(boss);
    }

    public void ReleaseNormal(NormalMonster normal)
    {
        normal.gameObject.SetActive(false);
        normalPool.Enqueue(normal);
    }
}
