using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] Transform attackTransform;
    [SerializeField] float attackRange = 1.5f;
    [SerializeField] LayerMask attackableLayer;
    [SerializeField] int damageAmount = 1;
    [SerializeField] float attackCD = 0.15f;

    RaycastHit2D[] hits;
    Animator anim;
    float attackCoolTimeCheck;

    public bool shouldBeDamage { get; set; }
    List<IDamageable> iDamageables = new List<IDamageable>();

    void Start()
    {
        anim = GetComponent<Animator>();
        attackCoolTimeCheck = attackCD;
    }

    void Update()
    {
        if (InputUser.Instance.control.Attack.MelleAttack.WasPressedThisFrame() && attackCoolTimeCheck >= attackCD)
        {
            attackCoolTimeCheck = 0;

            anim.SetTrigger("attack");
        }

        attackCoolTimeCheck += Time.deltaTime;
    }

    public IEnumerator AttackAvailable()
    {
        shouldBeDamage = true;

        while (shouldBeDamage)
        {
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0, attackableLayer);

            for (int i = 0; i < hits.Length; i++)
            {
                IDamageable enemyHealth = hits[i].collider.GetComponent<IDamageable>();

                if (enemyHealth != null && !enemyHealth.hasTakenDamage)
                {
                    enemyHealth.Damage(damageAmount, transform.right);
                    iDamageables.Add(enemyHealth);
                }
            }

            yield return null;
        }

        ReturnAttackableState();
    }

    private void ReturnAttackableState()
    {
        foreach (var damagable in iDamageables)
        {
            damagable.hasTakenDamage = false;
        }

        iDamageables.Clear();
    }

    public void ShouldBeDamageTrue()
    {
        shouldBeDamage = true;
    }

    public void ShouldBeDamageFalse()
    {
        shouldBeDamage = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }
}
