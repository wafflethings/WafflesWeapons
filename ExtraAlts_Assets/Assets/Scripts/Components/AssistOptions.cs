using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssistOptions : MonoBehaviour
{
    public Toggle majorEnable;
    public Slider gameSpeed;
    public Slider damageTaken;
    public Toggle infiniteStamina;
    public Toggle disableWhiplashHardDamage;
    public Toggle disableHardDamage;
    public Toggle disableWeaponFreshness;
    public Toggle autoAim;
    public Slider autoAimSlider;
    public Dropdown bossDifficultyOverride;
    public Toggle hidePopup;

    public GameObject autoAimGroup;
    public GameObject majorPopup;
    public GameObject majorBlocker;

     
    void Start() { }
    public void MajorCheck() { }
    public void MajorEnable() { }
    public void GameSpeed(float stuff) { }
    public void DamageTaken(float stuff) { }
    public void InfiniteStamina(bool stuff) { }
    public void DisableWhiplashHardDamage(bool stuff) { }
    public void DisableHardDamage(bool stuff) { }
    public void DisableWeaponFreshness(bool stuff) { }
    public void HidePopup(bool stuff) { }
    public void AutoAim(bool stuff) { }
    public void AutoAimAmount(float stuff) { }
    public void BossDifficultyOverride(int stuff) { }}
