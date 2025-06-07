using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [Header("업그레이드레벨")]
    public TextMeshProUGUI[] upgradeLevelText;
    
    [Header("스킬버튼")]
    public Button[] skillButtons;
    public TextMeshProUGUI[] skillStackText;
    public Button clickedButton;


    [Header("스킬설명")]
    public GameObject skillDescriptionPanel;
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillGrade;
    public TextMeshProUGUI skillAttackPower;
    public TextMeshProUGUI skillRange;
    public TextMeshProUGUI skillCooldown;
    public TextMeshProUGUI skillElementType;
    public TextMeshProUGUI skillDescription;

    public void Init()
    {
        for (int i = 0; i < skillStackText.Length; i++)
        {
            skillStackText[i].text = "";
        }
        for (int i = 0; i < skillButtons.Length; i++)
        {
            int index = i;
            skillButtons[i].onClick.AddListener(() => OnSkillButtonClicked(index));
        }
    }

    public void OnSkillButtonClicked(int i)
    {
        if (clickedButton != null && clickedButton == skillButtons[i])
        {
            clickedButton = null;
        }
        else
        {
            clickedButton = skillButtons[i];
        }
    }

    public void UpdateSkillUI(int index, int stackCount)
    {
        if (stackCount==0) skillStackText[index].text = "";
       else skillStackText[index].text = stackCount.ToString();
    }
}
