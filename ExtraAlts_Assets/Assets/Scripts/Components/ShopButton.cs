using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public bool deactivated;
    public bool failure;
    public GameObject clickSound;
    public GameObject failSound;
    public GameObject[] toActivate;
    public GameObject[] toDeactivate;
    public VariationInfo variationInfo;

    void Awake() { }
    void OnPointerClick() { }}
