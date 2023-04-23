using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class WeaponHUD : MonoSingleton<WeaponHUD> {

	 
	protected override void Awake () { }
    public void UpdateImage(Sprite icon, Sprite glowIcon, int variation) { }}
