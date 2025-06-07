using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{

    [Header("��ư")]
    public Button skillCreateButton;
    public Button createLevelUpgradeButton;

    [Header("�����")]
    public TextMeshProUGUI skillCreateGoldText;
    public TextMeshProUGUI createLevelUpgradeGoldText;
    public void Init()
    {
        skillCreateButton.onClick.AddListener(OnSkillCreateButtonClicked);
    }

    public void OnSkillCreateButtonClicked()
    {
        SkillManager.Instance.CreateSkill();
    }

    public void UpdateSkillCreateGold(int gold)
    {
        skillCreateGoldText.text = gold.ToString();
    }
}
