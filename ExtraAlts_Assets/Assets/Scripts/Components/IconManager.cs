using System;
using System.Linq;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class IconManager : MonoSingleton<IconManager>
{
    [SerializeField] private CheatAssetObject[] iconPacks;

    public int CurrentIconPackId {get;set;}    public CheatAssetObject CurrentIcons {get;set;}
    public void SetIconPack(int pack) { }
    public void Reload() { }}
