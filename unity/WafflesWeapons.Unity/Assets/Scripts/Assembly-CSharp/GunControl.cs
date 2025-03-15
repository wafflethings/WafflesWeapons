using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class GunControl : MonoSingleton<GunControl>
{
	private InputManager inman;

	public bool activated;

	private int rememberedSlot;

	public int currentVariationIndex;

	public int currentSlotIndex;

	public GameObject currentWeapon;

	public List<List<GameObject>> slots;

	public List<GameObject> slot1;

	public List<GameObject> slot2;

	public List<GameObject> slot3;

	public List<GameObject> slot4;

	public List<GameObject> slot5;

	public List<GameObject> slot6;

	public List<GameObject> allWeapons;

	public Dictionary<GameObject, int> slotDict;

	public List<WeaponIcon> currentWeaponIcons;

	private AudioSource aud;

	public float killCharge;

	public Slider killMeter;

	public bool noWeapons;

	public int lastSlotIndex;

	public int lastVariationIndex;

	private Dictionary<int, int> retainedVariations;

	public float headShotComboTime;

	public int headshots;

	private bool hookCombo;

	private StyleHUD shud;

	public GameObject[] gunPanel;

	private float scrollCooldown;

	private const float WeaponWheelTime = 0.25f;

	[HideInInspector]
	public int dualWieldCount;

	[HideInInspector]
	public bool stayUnarmed;

	[HideInInspector]
	public bool variationMemory;

	public event Action<GameObject> OnWeaponChange
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	protected override void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPrefChanged(string id, object value)
	{
	}

	private void CalculateSlotCount()
	{
	}

	private void Update()
	{
	}

	private void OnGUI()
	{
	}

	private void RetainVariation(int slot, int variationIndex)
	{
	}

	private int loop(int x, int m)
	{
		return 0;
	}

	public void SwitchWeapon(int targetSlotIndex, int? targetVariationIndex = null, bool useRetainedVariation = false, bool cycleSlot = false, bool cycleVariation = false)
	{
	}

	public void ForceWeapon(GameObject weapon, bool setActive = true)
	{
	}

	public void NoWeapon()
	{
	}

	public void YesWeapon()
	{
	}

	public void AddKill()
	{
	}

	public void ClearKills()
	{
	}

	public void UpdateWeaponList(bool firstTime = false)
	{
	}

	public void UpdateWeaponIcon(bool firstTime = false)
	{
	}
}
