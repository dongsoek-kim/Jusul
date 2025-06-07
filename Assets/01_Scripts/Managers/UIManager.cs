using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }


    [Header("UI Elements")]
    public SkillUI skillUI;
    public UnderBarUI underBarUI;
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

        skillUI.Init();
        underBarUI.Init();
    }
}
