using UnityEngine;
using UnityEngine.UI;

public class UnderBarUI : MonoBehaviour
{

    [Header("��ų���� ��ư")]
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
