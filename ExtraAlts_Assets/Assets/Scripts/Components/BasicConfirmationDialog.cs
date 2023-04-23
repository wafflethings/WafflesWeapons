using System;
using UnityEngine;
using UnityEngine.Events;

public class BasicConfirmationDialog : MonoBehaviour
{
    [SerializeField] private GameObject blocker;
    [SerializeField] private UnityEvent onConfirm;

    public void ShowDialog() { }
    private void Update() { }
    public void Confirm() { }    
    public void Cancel() { }}