using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class EnemyHealth : BaseHealth
{
    CinemachineImpulseSource _impulseSource;
    [SerializeField] ScreenShakeSO profile;

    HPBar _hpBar;

    protected override void Start()
    {
        base.Start();
        _impulseSource = GetComponent<CinemachineImpulseSource>();
        _hpBar = GetComponentInChildren<HPBar>();
    }

    public override void Damage(int amount, Vector2 attackDirection)
    {
        hasTakenDamage = true;
        CurrentHealth -= amount;
        _hpBar.UpdateHPBar(MaxHealth, CurrentHealth);
        CameraShakeManager.Instance.CameraShakeFromProfile(_impulseSource, profile);

        PlayRandomSFX();

        SpawnDamageParticle(attackDirection);

        Die();
    }
}
