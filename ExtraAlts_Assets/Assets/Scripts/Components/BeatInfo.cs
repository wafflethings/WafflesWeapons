using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatInfo : MonoBehaviour
{
    public float bpm;
    public float timeSignature;

    public TimeSignatureChange[] timeSignatureChanges;

    public void SetValues() { }}

[Serializable]
public class TimeSignatureChange
{
    public float onMeasure;
    public float timeSignature;
}
