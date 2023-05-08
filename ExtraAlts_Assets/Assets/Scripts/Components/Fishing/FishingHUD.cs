using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fishing;
using UnityEngine;
using UnityEngine.UI;

public class FishingHUD : MonoSingleton<FishingHUD>
{
    [SerializeField] private GameObject powerMeterContainer;
    [SerializeField] private Slider powerMeter;
    
    [SerializeField] private GameObject hookedContainer;
    [Space] [SerializeField] private GameObject fishCaughtContainer;
    [SerializeField] private Text fishCaughtText;
    [SerializeField] private GameObject fishRenderContainer;
    [SerializeField] private GameObject fishSizeContainer;
    
    [Space] [SerializeField] private GameObject struggleContainer;
    [SerializeField] private GameObject outOfWaterMessage;
    [SerializeField] private Image struggleProgressIcon;
    [SerializeField] private Image struggleProgressIconOverlay;
    [SerializeField] private Image struggleNub;
    [SerializeField] private RectTransform desireBar;
    [SerializeField] private RectTransform fishIcon;
    [SerializeField] private Slider struggleProgressSlider;
    [SerializeField] private Text struggleLMB;
    [SerializeField] private Text struggleRMB;
    [SerializeField] private Image upArrow;
    [SerializeField] private Image downArrow;
    
    [Space] [SerializeField] private Image fishIconTemplate;
    [SerializeField] private Transform fishIconContainer;
    private float containerHeight {get;set;}
    private void Start() { }
    public void ShowHUD() { }
    public void SetFishHooked(bool hooked) { }
    protected override void OnEnable() { }
    private void OnDisable() { }
    public void SetState(FishingRodState state) { }
    public void SetPowerMeter(float value, bool canFish) { }
    private void Update() { }
    public void ShowFishCaught(bool show = true, FishObject fish = null) { }
    public void ShowOutOfWater() { }
    public void SetStruggleProgress(float progress, Sprite fishIconLocked, Sprite fishIconUnlocked) { }
    public void SetStruggleSatisfied(bool satisfied) { }
    public void SetPlayerStrugglePosition(float pos) { }
    public void SetFishDesire(float top, float bottom)  { }}