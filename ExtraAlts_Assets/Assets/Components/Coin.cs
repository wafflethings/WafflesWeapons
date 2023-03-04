using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public LayerMask lmask;
    public GameObject refBeam;
    public Vector3 hitPoint = Vector3.zero;
    public bool shot;
    public GameObject coinBreak;
    public float power;

    public bool quickDraw;

    public Material uselessMaterial;
    public GameObject coinHitSound;
    public bool doubled;

    public GameObject flash;
    public GameObject chargeEffect;

    public CoinChainCache ccc;

    public void DelayedReflectRevolver(Vector3 hitp, GameObject beam = null)
{}
    public void ReflectRevolver()
{}
    public void DelayedPunchflection()
{}
    public void Punchflection()
{}
    public void GetDeleted()
{}}
