using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkilltreeStorage : Storage
{
    public override void SetSlot()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            UISkillSlot slot = slots[i] as UISkillSlot;

            slots[i].UpdateUI(items[i]);
            slots[i].SetupStorage(this);
            slots[i].SetupMouseDrag(this);

            if(!slot.Unlocked)
            {
                slot.LockMouseDrag();
            }
        }
    }

    public override void Start()
    {
        base.Start();

        foreach (var slot in slots)
        {
            UISkillSlot skillSlot = slot as UISkillSlot;
            skillSlot.OnskillUnlock += SetSlot;
        }
    }
}
