using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour
{
    [FormerlySerializedAs("descriptor")]
    public WeaponDescriptor weaponDescriptor;

    [SerializeField] Renderer[] variationColoredRenderers;
    [SerializeField] Material[] variationColoredMaterials;
    [SerializeField] Image[] variationColoredImages;

    private void OnEnable() { }
    public void UpdateMaterials() { }
    public void UpdateIcon() { }}
