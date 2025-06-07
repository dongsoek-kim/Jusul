using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Money { get; private set; }// 게임 머니

    private float spawnTimer = 0f;

    void Awake()
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
        GameStart();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 2f)  
        {
            PoolManager.Instance.Spawn<NormalMonster>("NormalMonster");
            spawnTimer = 0f;  
        }
    }

    void GameStart()
    {
        Money = 200;
    }

    public void UseMoney(int amount)
    {
        Money -= amount;
        UIManager.Instance.UpdateMoneyText(Money);
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        UIManager.Instance.UpdateMoneyText(Money);
    }
}
