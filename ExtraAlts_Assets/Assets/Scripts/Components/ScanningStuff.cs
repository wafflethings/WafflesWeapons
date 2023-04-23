using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class ScanningStuff : MonoSingleton<ScanningStuff>
{
    [SerializeField] private GameObject scanningPanel;
    [SerializeField] private GameObject readingPanel;
    [SerializeField] private Text readingText;
    [SerializeField] private ScrollRect scrollRect;
    public Image meter;

    public bool oldWeaponState;

    public bool IsReading {get;set;}
    public void ReleaseScroll(int instanceId) { }
    public void ScanBook(string text, bool noScan, int instanceId) { }
    public void ResetState() { }
    void Update() { }}
