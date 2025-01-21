using Cinemachine;
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
        Die();
    }

    public void Die()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
