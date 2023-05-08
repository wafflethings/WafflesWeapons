using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public bool match;
    public bool oneTime;
    public bool onEnable;
    public bool dontStart;
    public bool forceOn;

    public AudioClip clean;
    public AudioClip battle;
    public AudioClip boss;

    private void OnEnable() { }
    public void Change() { }}
