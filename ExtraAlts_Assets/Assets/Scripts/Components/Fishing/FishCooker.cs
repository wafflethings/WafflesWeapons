using System;
using System.Collections;
using UnityEngine;

public class FishCooker : MonoBehaviour
{
    [SerializeField] private bool unusable = false;
    
    [SerializeField] private ItemIdentifier fishPickupTemplate;
    [SerializeField] private FishObject cookedFish;
    [SerializeField] private FishObject failedFish;
    [SerializeField] private GameObject cookedSound;
    [SerializeField] private GameObject cookedParticles;
}
