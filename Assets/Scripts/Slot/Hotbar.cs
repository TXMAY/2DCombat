using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : Storage
{
    public Transform player;

    void Update()
    {
        HotKey();
    }

    private void HotKey()
    {
        KeyCode[] hotkeys = { KeyCode.Q, KeyCode.W };

        for (int i = 0; i < hotkeys.Length; i++)
        {
            if(Input.GetKey(hotkeys[i]))
            {
                items[i].skillData.CastSpell(player);
            }
        }
    }
}
