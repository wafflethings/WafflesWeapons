using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishingRodWeapon : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private FishingRodTarget targetPrefab;
    [SerializeField] private FishBait baitPrefab;
    [SerializeField] private Transform rodTip;
    [SerializeField] private ItemIdentifier fishPickupTemplate;
    public AudioSource pullSound;

    private float bottomBound {get;set;}    private float topBound {get;set;}    private bool struggleSatisfied {get;set;}
    private Vector3 approximateTargetPosition {get;set;}
    
    public void ThrowBaitEvent() { }
    private void OnEnable() { }
    public void FishCaughtAndGrabbed() { }
    private void OnGUI() { }
    private void Update() { }}

public enum FishingRodState { ReadyToThrow, SelectingPower, Throwing, WaitingForFish, FishStruggle }
