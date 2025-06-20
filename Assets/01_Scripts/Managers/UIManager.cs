using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }


    [Header("UI Elements")]
    public SkillUI skillUI;
    public ButtonUI buttonUI;
    public InformationUI informationUI;
    public GameOverUI gameOverUI;
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
    }
    private void Start()
    { 
        skillUI.Init();
        buttonUI.Init();
        informationUI.Init();
    }

    public void SkillUIUdate(int index,int stack,int requirementMoney)
    {
        skillUI.UpdateSkillUI(index, stack);
        informationUI.UpdateSkillAmount();
        buttonUI.UpdateSkillCreateGold(requirementMoney);
    }
    public void CreateLeveUIUpdate(int requirementUpgradeMoney)
    {
        buttonUI.UpdateCreateLevelUpgradeGold(requirementUpgradeMoney);
    }
    public void Alarm(string text)
    {
        informationUI.Alarm(text);
    }

    public void UpdateMoneyText(int money)
    {
        informationUI.UpdateMoneyText(money);
    }
    public void UpdateWave(int wave)
    {
        informationUI.UpdateWave(wave);
    }
    public void UpdateWaveTimer(string timeText)
    {
        informationUI.UpdateWaveTimer(timeText);
    }

    public void GameOver()
    {
        gameOverUI.gameObject.SetActive(true);
        gameOverUI.playerCanvas.gameObject.SetActive(false);
        informationUI.gameObject.SetActive(false);
        skillUI.gameObject.SetActive(false);
        buttonUI.gameObject.SetActive(false);
    }
}
