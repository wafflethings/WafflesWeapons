using UnityEngine;

public class SetFishZone : MonoBehaviour
{
    [SerializeField] private bool onEnter = true;
    [SerializeField] private bool restorePreviousOnExit = true;
    public float suggestedFishingDistance = 1f;
    [SerializeField] private bool customMinDistance = false;
    [SerializeField] private float minDistance = 1f;

    public void Set() { }    
    public void Restore() { }}
