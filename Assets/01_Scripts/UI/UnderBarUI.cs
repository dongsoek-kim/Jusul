using UnityEngine;
using UnityEngine.UI;

public class UnderBarUI : MonoBehaviour
{

    [Header("스킬생성 버튼")]
    public Button skillCreateButton;

    public void Init()
    {
        skillCreateButton.onClick.AddListener(OnSkillCreateButtonClicked);
    }

    public void OnSkillCreateButtonClicked()
    {
        SkillManager.Instance.CreateSkill();
    }
}
