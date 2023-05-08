using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class FishBait : MonoBehaviour
{
    public Transform baitPoint;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject splashPrefab;
    [SerializeField] private GameObject fishHookedPrefab;
    public bool landed = true;
    public float flyProgress = 0f;
    public bool allowedToProgress;

     
     
     
     

    private void Update() { }
    public void ThrowStart(Vector3 targetWorldPosition, Transform inPar, FishingRodWeapon srcWpn) { }
    public void FishHooked() { }
    public void Dispose() { }
    public void CatchFish(FishObject fish) { }
    public void OutOfWater() { }
    public void OnTriggerExit(Collider other) { }
    public void OnCollisionEnter(Collision collision) { }}