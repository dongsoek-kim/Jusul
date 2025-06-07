using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [Header("���׷��̵巹��")]
    public TextMeshProUGUI[] upgradeLevelText;
    
    [Header("��ų��ư")]
    public Button[] skillButtons;
    public TextMeshProUGUI[] skillStackText;
    // Start is called before the first frame update
    public Button clickedButton;


    [Header("��ų����")]
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
        Debug.Log("Skill Button " + i + " clicked");
        if (clickedButton != null && clickedButton == skillButtons[i])
        {
            Debug.Log("Skill Button " + i + " already clicked");
            clickedButton = null;
        }
        else
        {
            clickedButton = skillButtons[i];
            Debug.Log("Skill Button " + i + " clicked");
        }
    }

    public void UpdateSkillUI(int index, int stackCount)
    {
        if (stackCount==0) skillStackText[index].text = "";
       else skillStackText[index].text = stackCount.ToString();

    }
}
