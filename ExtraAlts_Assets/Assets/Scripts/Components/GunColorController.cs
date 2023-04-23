using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class GunColorPreset
{
    public Color color1;
    public Color color2;
    public Color color3;

    public GunColorPreset(Color a, Color b, Color c) { }}

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class GunColorController : MonoSingleton<GunColorController>
{

    public GunColorPreset[] revolverColors;
    public GunColorPreset[] shotgunColors;
    public GunColorPreset[] nailgunColors;
    public GunColorPreset[] railcannonColors;
    public GunColorPreset[] rocketLauncherColors;

    void Start() { }
    public void UpdateGunColors() { }}
