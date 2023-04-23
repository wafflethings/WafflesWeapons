using System;
using UnityEngine.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossHealthBar : MonoBehaviour
{
    public HealthLayer[] healthLayers;
    public string bossName;
    public bool secondaryBar;
    [SerializeField] private Color secondaryColor = Color.white;
    
    void Awake() {}
    private void OnEnable() { }    private void OnDisable() { }
    public void UpdateSecondaryBar(float value) { }
    public void SetSecondaryBarColor(Color clr) { }    
    void Update () { }
    public void DestroyBar() { }
    public void DisappearBar() { }}
