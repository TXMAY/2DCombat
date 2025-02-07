using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkillSlot : UISlot
{
    public Action OnskillUnlock;

    bool unlocked;
    public bool Unlocked => unlocked;
    [Tooltip("shouldBeUnlocked가 모두 true여야 해금이 가능")]
    [SerializeField] UISkillSlot[] shouldBeUnlocked;
    [SerializeField] UISkillSlot[] shouldBelocked;

    [SerializeField] Item item;
    Button _button;

    void Start()
    {
        itemImage = GetComponent<Image>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(UnlockSkillSlot);

        if (!unlocked) itemImage.color = Color.red;
    }

    void OnValidate()
    {
        gameObject.name = $"SkillTreeSlot_UI - {item.itemName}";
    }

    private void UnlockSkillSlot()
    {
        if (unlocked) return;

        for (int i = 0; i < shouldBeUnlocked.Length; i++)
        {
            if (shouldBeUnlocked[i].unlocked == false) return;
        }

        for (int i = 0; i < shouldBelocked.Length; i++)
        {
            if (shouldBelocked[i].unlocked == true) return;
        }

        unlocked = true;
        itemImage.color = Color.white;
        OnskillUnlock?.Invoke();
    }
}
