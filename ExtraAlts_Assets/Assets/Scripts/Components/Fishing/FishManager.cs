using System;
using System.Collections.Generic;
using System.Linq;
using Logic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class FishManager : MonoSingleton<FishManager>
{
    [SerializeField] private FishDB[] fishDbs;
    public Dictionary<FishObject, bool> recognizedFishes = new Dictionary<FishObject, bool>();
    public Action<FishObject> onFishUnlocked;
    
     
    public int RemainingFishes {get;set;}
    protected override void Awake() { }}
