using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectableRectTools : MonoBehaviour
{
    [SerializeField] private Selectable target;
    [SerializeField] private bool autoSwitchForDown;
    [SerializeField] private bool autoSwitchForUp;
    [SerializeField] private Selectable[] prioritySwitch;

    private void OnEnable() { }
    public void ChangeSelectOnUp(Selectable newElement) { }
    public void ChangeSelectOnDown(Selectable newElement) { }}