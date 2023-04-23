using System;
using UnityEngine;

public class PlayerActivatorRelay : MonoSingleton<PlayerActivatorRelay>
{
    [SerializeField] private GameObject[] toActivate;
    [SerializeField] private GameObject gunPanel;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private float delay = 0.2f;

    private void Start() { }
    public void Activate() { }}