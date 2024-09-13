using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemyAnimator : EnemyAnimator
{
    [SerializeField] private Image bossAttackIndicator;
    [SerializeField] private Image bossAttackIndicatorFillImage;

    protected override void Awake()
    {
        base.Awake();

        UpdateAttackIndicator();
        bossAttackIndicator.gameObject.SetActive(false);
    }

    private void UpdateAttackIndicator()
    {
        bossAttackIndicator.rectTransform.anchoredPosition = enemyAttack.GetAttackAreaCenter();
        bossAttackIndicator.rectTransform.sizeDelta = enemyAttack.GetAttackArea();
    }

    protected override void EnemyAttack_OnAttackStart(object sender, EventArgs e)
    {
        bossAttackIndicator.gameObject.SetActive(true);
        bossAttackIndicatorFillImage.fillAmount = 0.0f;

        UpdateAttackIndicator();
    }

    protected override void EnemyAttack_OnAttackComplete(object sender, EventArgs e)
    {
        bossAttackIndicator.gameObject.SetActive(false);
    }

    protected override void EnemyAttack_OnAttackChargeAmountUpdate(object sender, float chargeAmount)
    {
        bossAttackIndicatorFillImage.fillAmount = chargeAmount;
    }

    protected override void EnemyAttack_OnRecovery(object sender, EventArgs e)
    {
        bossAttackIndicator.gameObject.SetActive(false);
    }
}