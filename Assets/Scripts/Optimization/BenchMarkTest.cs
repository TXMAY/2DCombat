using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchMarkTest : MonoBehaviour
{
    Animator playerAnimator;

    int _attackTrigger = Animator.StringToHash("attack");

    void Awake()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    public void PerformBenchMarkTest()
    {
        //playerAnimator.SetTrigger("attack");
        playerAnimator.SetTrigger(_attackTrigger);
    }

}
