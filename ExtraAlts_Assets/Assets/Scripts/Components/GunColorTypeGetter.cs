using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunColorTypeGetter : MonoBehaviour
{
    public int weaponNumber;
    public bool altVersion;
    public GameObject template;
    public GameObject custom;
    public GameObject altButton;

    public GunColorGetter[] previewModel;

    public Image[] templateButtons;
    public Text[] templateTexts;

    void Awake() { }
    void OnEnable() { }
    public void SetType(bool isCustom) { }
    public void SetPreset(int target) { }
    public void UpdatePreview() { }
    public void UpdateButtons(int target) { }}
