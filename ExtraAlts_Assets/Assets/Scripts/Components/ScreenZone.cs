using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScreenZone : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private float angleLimit = 0f;
    [SerializeField] private Transform angleSourceOverride;
     
    [Space] [SerializeField] protected UnityEvent onEnterZone = new UnityEvent();
    [SerializeField] protected UnityEvent onExitZone = new UnityEvent();
    private void OnDisable() { }
    public virtual void UpdatePlayerState(bool active) { }
    protected virtual void Update() { }}
