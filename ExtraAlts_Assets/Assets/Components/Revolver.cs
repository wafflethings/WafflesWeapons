using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using UnityEngine.UI;


public class Revolver : MonoBehaviour
{

    public int gunVariation;
    public bool altVersion;

    public Transform kickBackPos;
    public AudioClip[] gunShots;
    public AudioClip[] superGunShots;
    public GameObject gunBarrel;
    public float shootCharge;
    public float pierceCharge;
    public float pierceShotCharge;

    public Vector3 shotHitPoint;
    public GameObject revolverBeam;
    public GameObject revolverBeamSuper;

    public RaycastHit hit;
    public RaycastHit[] allHits;

    public float recoilFOV;
    public GameObject chargeEffect;
    public Vector3 beamReflectPos;

    public MeshRenderer screenMR;
    public Material batteryMat;
    public Texture2D batteryFull;
    public Texture2D batteryMid;
    public Texture2D batteryLow;
    public Texture2D[] batteryCharges;
    public AudioClip chargedSound;
    public AudioClip chargingSound;
    public AudioClip twirlSound;
    public bool twirlRecovery;
    public GameObject coin;

    public Image[] coinPanels;

    public void Punch() {}
    public void ReadyGun() {}
    
}
