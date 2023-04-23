using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class FistControl : MonoSingleton<FistControl>
{
    public ForcedLoadout forcedLoadout;

    public GameObject blueArm;
    public GameObject redArm;
    public GameObject goldArm;
    public bool shopping;

    public GameObject[] fistPanels;
    public Image fistIcon;

    public ItemIdentifier heldObject;

    public float fistCooldown;
    public float weightCooldown;

    public bool activated
{get;set;}
    public GameObject currentArmObject {get;set;}    public Punch currentPunch;
    
     
    void Start() { }
     
    void Update() { }
    public void ScrollArm() { }
    public void RefreshArm() { }
    public void ForceArm(int varNum, bool animation = false) { }
    public void ArmChange(int orderNum) { }
    public void UpdateFistIcon() { }
    public void NoFist() { }
    public void YesFist() { }
    public void ResetFists() { }
    public void ShopMode() { }
    public void StopShop() { }
    public void ResetHeldItemPosition() { }
    public void TutorialCheckForArmThatCanPunch() { }}
