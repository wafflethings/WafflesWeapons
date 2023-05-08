using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class VirtueController : MonoSingleton<VirtueController>
{
    public float cooldown;
    public int currentVirtues;

    private void Update() { }}
