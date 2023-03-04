using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class HUDOptions : MonoSingleton<HUDOptions>
{
    public Dropdown hudType;

    public Slider bgOpacity;

    public Toggle weaponIcon;
    public Toggle armIcon;
    public Toggle railcannonMeter;
    public Toggle styleMeter;
    public Toggle styleInfo;
    public Dropdown crossHairType;
    public Dropdown crossHairColor;
    public Dropdown crossHairHud;
    public Toggle crossHairHudFade;

    public void CrossHairType(int stuff)
{}
    public void CrossHairColor(int stuff)
{}
    public void CrossHairHud(int stuff)
{}
    public void HudType(int stuff)
{}
    public void HudFade(bool stuff)
{}
    public void BgOpacity(float stuff)
{}
    public void WeaponIcon(bool stuff)
{}
    public void ArmIcon(bool stuff)
{}
    public void RailcannonMeterOption(bool stuff)
{}
    public void StyleMeter(bool stuff)
{}
    public void StyleInfo(bool stuff)
{}}
