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
            Debug.Log("같은버튼눌렀다");
            skillDescriptionPanel.SetActive(false);
            if(i%6!=5)SkillManager.Instance.CombinSkill(i);
            clickedButton = null;
        }
        else
        {
            Debug.Log("다른버튼눌렀다");
            clickedButton = skillButtons[i];
            skillDescriptionPanel.SetActive(true);
            skillName.text = SkillManager.Instance.GetSkillName(i);
            skillGrade.text = SkillManager.Instance.GetSkillGrade(i);
            skillAttackPower.text = SkillManager.Instance.GetSkillAttackPower(i);
            skillRange.text = SkillManager.Instance.GetSkillRange(i);
            skillCooldown.text = SkillManager.Instance.GetSkillCooldown(i);
            skillElementType.text = SkillManager.Instance.GetSkillElementType(i);
            skillDescription.text = SkillManager.Instance.GetSkillDescription(i);
        }
    }
    public void UpdateSkillUI(int index, int stackCount)
    {
        if (stackCount == 0)
        {
            skillStackText[index].text = "";
            skillButtons[index].GetComponent<Image>().color = new Color(0.7f,0.7f,0.7f);
        }
        else
        {
            skillStackText[index].text = stackCount.ToString();
            skillButtons[index].GetComponent<Image>().color = Color.white;

        }
    }
}
