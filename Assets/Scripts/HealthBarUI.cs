using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private Image healthBarFillImage;
    [SerializeField] private TextMeshProUGUI hpText;

    private void Start()
    {
        healthSystem.OnHPChanged += HealthSystem_OnHPChanged;

        UpdateHealthBarUI();
    }

    private void UpdateHealthBarUI()
    {
        hpText.text = $"{healthSystem.GetCurrentHP():F0}";
        healthBarFillImage.fillAmount = healthSystem.GetHPAmount();
    }

    private void HealthSystem_OnHPChanged(object sender, EventArgs e)
    {
        UpdateHealthBarUI();
    }
}
