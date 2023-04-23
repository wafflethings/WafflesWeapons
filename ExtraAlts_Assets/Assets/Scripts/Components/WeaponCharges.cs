using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class WeaponCharges : MonoSingleton<WeaponCharges>
{

    public float rev0charge = 100;
    public bool rev0alt = false;
    public float rev1charge = 400;
    public float naiHeatsinks = 2;
    public float naiSawHeatsinks = 1;
    public float naiheatUp = 0;
    public float naiAmmo = 100;
    public float naiSaws = 10;
    public bool naiAmmoDontCharge;
    public float naiMagnetCharge = 3;

    public float raicharge = 5;

    public GameObject railCannonFullChargeSound;
    public bool railChargePlayed;
    public float rocketcharge = 0;
    public float rocketFreezeTime = 5;
    public int rocketCount = 0;
    public TimeSince timeSinceIdleFrozen;
    public float rocketCannonballCharge = 1;

    public float[] revaltpickupcharges = new float[3];

     
    void Update() { }
    public void Charge(float amount) { }
    public void MaxCharges() { }
    public void PlayRailCharge() { }}
