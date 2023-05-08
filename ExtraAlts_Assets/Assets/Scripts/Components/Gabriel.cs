using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GabrielWeaponType
{
    Sword,
    Zweihander,
    Axe,
    Spear,
    Glaive
}

public class Gabriel : MonoBehaviour
{
    public GameObject particles;
    public GameObject particlesEnraged;
    public Material enrageBody;
    public Material enrageWing;

    public bool enraged;
    public bool secondPhase;
    public float phaseChangeHealth;
    public GameObject teleportSound;
    public GameObject decoy;

    public Transform rightHand;
    public Transform leftHand;

    public GameObject sword;
    public GameObject zweiHander;
    public GameObject axe;
    public GameObject spear;
    public GameObject glaive;
    public GameObject dashEffect;
    public GameObject juggleEffect;

    public GameObject summonedSwords;

    public Transform head;
    [SerializeField] GameObject genericOutro;

     
    void Start() { }
    void SetValues() { }
    void UpdateBuff() { }
    void UpdateSpeed() { }
    private void OnDisable() { }
    void OnEnable() { }
     
    void Update() { }
    private void FixedUpdate() { }
    public void Teleport(bool closeRange = false, bool longrange = false, bool firstTime = true, bool horizontal = false, bool vertical = false) { }
    void StingerCombo() { }
    void SpearCombo() { }
    void ZweiDash() { }
    void StartDash() { }
    void ZweiCombo() { }
    void AxeThrow() { }
    void SpearAttack() { }
    void SpearFlash() { }
    void SpearGo() { }
    void JuggleStart() { }
    void JuggleStop(bool enrage = false) { }
    void Enrage() { }
    public void EnrageNow() { }
    public void UnEnrage() { }
    void SpearThrow() { }
    void ThrowWeapon(GameObject projectile) { }
    void CheckForThrown() { }
    public void EnableWeapon() { }
    public void DisableWeapon() { }
    void RandomizeDirection() { }
    void SpawnLeftHandWeapon(GabrielWeaponType weapon) { }
    void SpawnRightHandWeapon(GabrielWeaponType weapon) { }
    public void DamageStartLeft(int damage) { }
    public void DamageStopLeft(int keepMoving) { }
    public void DamageStartRight(int damage) { }
    public void DamageStopRight(int keepMoving) { }
    public void SetForwardSpeed(int newSpeed) { }
    public void EnrageTeleport(int teleportType = 0) { }
    void ResetAnimSpeed() { }
    public void LookAtTarget(int instant = 0) { }
    public void FollowTarget() { }
    public void StopAction() { }
    public void ResetWingMat() { }
    public void Death() { }
    void SpawnSummonedSwords() { }}
