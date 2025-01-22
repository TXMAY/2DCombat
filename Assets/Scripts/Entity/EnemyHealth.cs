using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class EnemyHealth : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int CurrentHealth { get; set; }
    [field: SerializeField] public int MaxHealth { get; set; } = 3;
    public bool hasTakenDamage { get; set; }

    CinemachineImpulseSource _impulseSource;
    [SerializeField] ScreenShakeSO profile;

    [SerializeField] AudioClip damageClip;

    public string HurtClipName;

    void Start()
    {
        CurrentHealth = MaxHealth;
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Damage(int amount)
    {
        hasTakenDamage = true;
        CurrentHealth -= amount;
        CameraShakeManager.Instance.CameraShakeFromProfile(_impulseSource, profile);

        PlayRandomSFX();
        
        
        Die();
    }

    private void PlayRandomSFX()
    {
        int randomIndex = UnityEngine.Random.Range(1, 6);

        string clipName = HurtClipName + randomIndex;

        SoundManager.Instance.PlaySFXFromString(clipName, 1f);
    }

    public void Die()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
