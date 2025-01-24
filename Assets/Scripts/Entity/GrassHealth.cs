using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassHealth : BaseHealth
{
    public override void Damage(int amount, Vector2 attackDirection)
    {
        hasTakenDamage = true;
        CurrentHealth -= amount;

        PlayRandomSFX();

        SpawnDamageParticle(attackDirection);

        Die();
    }
}
