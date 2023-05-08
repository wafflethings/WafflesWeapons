using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishEncyclopedia : MonoBehaviour
{
    [SerializeField] private GameObject fishPicker;
    [SerializeField] private GameObject fishInfoContainer;
    [SerializeField] private Text fishName;
    [SerializeField] private Text fishDescription;
    [Space] [SerializeField] private Transform fishGrid;
    [SerializeField] private FishMenuButton fishButtonTemplate;
    [SerializeField] private GameObject fish3dRenderContainer;
    [Space] [SerializeField] private FishDB[] fishDbs;

    private void Start() { }
    public void SelectFish(FishObject fish) { }
    public void HideFishInfo() { }}
