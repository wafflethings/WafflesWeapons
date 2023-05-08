using UnityEngine;
using UnityEngine.Events;

public class PlayerInputHooks : MonoBehaviour
{
    [Header("Fire1")]
    [SerializeField] private UnityEvent onFire1Pressed;
    [SerializeField] private UnityEvent onFire1Released;
    [Space] [Header("Fire2")] [SerializeField] private UnityEvent onFire2Pressed;
    [SerializeField] private UnityEvent onFire2Released;
    [Space] [Header("Slide")] [SerializeField] private UnityEvent onSlideInputStart;
    [SerializeField] private UnityEvent onSlideInputEnd;
    [Space] [Header("Jump")] [SerializeField] private UnityEvent onJumpPressed;
    [SerializeField] private UnityEvent onJumpReleased;
    [Header("Dash")] [SerializeField] private UnityEvent onDashPressed;
    [SerializeField] private UnityEvent onDashReleased;

    private void Update() { }}