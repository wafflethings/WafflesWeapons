using UnityEngine;

public class UnlockableFound : MonoBehaviour
{
    [SerializeField] private UnlockableType unlockableType;
    [SerializeField] private bool unlockOnEnable = true;
    [SerializeField] private bool unlockOnTriggerEnter = false;
    
    private void OnEnable() { }    
    public void Unlock() { }}