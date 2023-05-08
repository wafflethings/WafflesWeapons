using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrateCounter : MonoSingleton<CrateCounter>
{
    public int crateAmount;
    [SerializeField] private Text display;
    public UltrakillEvent onAllCratesGet;
    
    void Start() { }
    public void AddCrate() { }
    public void AddCoin() { }
    public void SaveStuff() { }
    public void CoinsToPoints() { }
    public void ResetUnsavedStuff() { }
    void UpdateDisplay() { }}
