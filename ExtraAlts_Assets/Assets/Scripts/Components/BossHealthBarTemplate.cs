using System;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBarTemplate : MonoBehaviour
{
    public Action onDestroy;
    public BossHealthSliderTemplate sliderTemplate;
    public Text bossNameText;
    public BossHealthSliderTemplate thinSliderTemplate;
    
    public void Initialize() { }
    public void ScaleChanged(float scale) { }}