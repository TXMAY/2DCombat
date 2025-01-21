using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScreenShake", menuName = "ShakeProfile")]
public class ScreenShakeSO : ScriptableObject
{
    public float listenerAmplitude = 1f;
    public float listenerFrequency = 1f;
    public float listenerDuration = 1f;

    public AnimationCurve impulseCurve;
    public float impactForce = 1f;
    public float impactTime = 0.2f;
    public Vector3 defaultVelocity = new Vector3(0, -1, 0);
}
