using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class HUDOptions : MonoSingleton<HUDOptions>
{
    public Dropdown hudType;

    public Slider bgOpacity;
    public Toggle alwaysOnTop;
    public Material hudMaterial;

    public Toggle weaponIcon;
    public Toggle armIcon;
    public Toggle railcannonMeter;
    public Toggle styleMeter;
    public Toggle styleInfo;
    [SerializeField] private Dropdown iconPackDropdown;
    public Dropdown crossHairType;
    public Dropdown crossHairColor;
    public Dropdown crossHairHud;
    public Toggle crossHairHudFade;
    [SerializeField] Toggle powerUpMeter;

     
    void Start() { }
    public void SetIconPack(int packId) { }
    public void CrossHairType(int stuff) { }
    public void CrossHairColor(int stuff) { }
    public void CrossHairHud(int stuff) { }
    public void HudType(int stuff) { }
    public void HudFade(bool stuff) { }
    public void PowerUpMeterEnable(bool stuff) { }
    public void BgOpacity(float stuff) { }
    public void AlwaysOnTop(bool stuff) { }
    public void WeaponIcon(bool stuff) { }
    public void ArmIcon(bool stuff) { }
    public void RailcannonMeterOption(bool stuff) { }
    public void StyleMeter(bool stuff) { }
    public void StyleInfo(bool stuff) { }}
