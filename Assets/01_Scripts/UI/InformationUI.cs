using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InformationUI : MonoBehaviour
{
    public TextMeshProUGUI waveNum;
    public TextMeshProUGUI waveTime;
    public TextMeshProUGUI money;
    public TextMeshProUGUI amount;

    public GameObject originalAlarmPanel;
    public Transform parentTransform;
    public void Init()
    {
        originalAlarmPanel.SetActive(false);
        waveNum.text = "1";
        waveTime.text = "00:20";
        money.text = GameManager.Instance.Money.ToString();
    }

    public void UpdateSkillAmount()
    {
        amount.text = SkillManager.Instance.SkillAmount.ToString();
    }
    public void Alarm(string text)
    {
        GameObject alarmPanel = Instantiate(originalAlarmPanel, parentTransform);
        alarmPanel.SetActive(true);

        var alarmText = alarmPanel.GetComponentInChildren<TextMeshProUGUI>();
        var canvasGroup = alarmPanel.GetComponent<CanvasGroup>();
        var rect = alarmPanel.GetComponent<RectTransform>();

        if (alarmText != null) alarmText.text = text;

        canvasGroup.alpha = 1f;
        rect.anchoredPosition = Vector2.zero;

        Sequence seq = DOTween.Sequence();

        seq.Append(rect.DOAnchorPosY(50f, 0.5f).SetEase(Ease.OutCubic)) 
           .Join(canvasGroup.DOFade(0f, 0.3f).SetDelay(0.2f))            
           .OnComplete(() =>
           {
               Destroy(alarmPanel);
           });
    }

    public void UpdateMoneyText(int moneyAmount)
    {
        money.text = moneyAmount.ToString();
    }

    public void UpdateWave(int wave)
    {
        waveNum.text = wave.ToString();
    }

    public void UpdateWaveTimer(string timeText)
    {
        waveTime.text = timeText;
    }
}
