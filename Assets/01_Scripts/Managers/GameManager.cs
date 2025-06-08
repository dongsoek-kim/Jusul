using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Money { get; private set; }// ���� �Ӵ�
    public Player player;

    private float spawnTimer = 0f;
    private float TotalWaveTime = 20f; // ��ü ���̺� �ð�
    private float WaveTime = 0f; // ���� ���̺� �ð�
    public int CurrentWave { get; private set; } = 1; // ���� ���̺� ��ȣ

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
        WaveTime += Time.deltaTime;

        float remaining = Mathf.Max(TotalWaveTime - WaveTime, 0f);
        int seconds = (int)(remaining % 60);

        // �ؽ�Ʈ ����: 00:00 ����
        string timeText = $"00:{seconds:00}";
        UIManager.Instance.UpdateWaveTimer(timeText);
        if (spawnTimer >= 2f)
        {
            PoolManager.Instance.Spawn<NormalMonster>("NormalMonster");
            spawnTimer = 0f;
        }
        if (WaveTime >= TotalWaveTime)
        {
            WaveTime = 0f;
            CurrentWave++;
            UIManager.Instance.UpdateWave(CurrentWave);
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

    public void GameOver()
    {
        UIManager.Instance.GameOver();
        player.gameObject.SetActive(false);
        Time.timeScale = 0f; // ���� �Ͻ� ����
    }
}