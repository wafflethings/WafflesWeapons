using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour
{
    public Sprite weaponIcon;
    public Sprite glowIcon;
    public int variationColor;

    [SerializeField] Renderer[] variationColoredRenderers;
    [SerializeField] Material[] variationColoredMaterials;
    [SerializeField] Image[] variationColoredImages;

    private void OnEnable() { }
    public void UpdateMaterials() { }
    public void UpdateIcon() { }}
