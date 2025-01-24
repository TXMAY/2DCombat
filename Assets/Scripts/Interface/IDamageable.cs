using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public bool hasTakenDamage {  get; set; }
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }

    public void Damage(int amount, Vector2 direction);
    public void Die();
}
