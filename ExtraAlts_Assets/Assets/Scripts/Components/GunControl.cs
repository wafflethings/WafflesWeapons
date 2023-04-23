using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class GunControl : MonoSingleton<GunControl>
{

	public bool activated = true;
	public int currentVariation;
	public int currentSlot;
	public GameObject currentWeapon;
	public List<List<GameObject>> slots = new List<List<GameObject>>();
	public List<GameObject> slot1 = new List<GameObject>();
	public List<GameObject> slot2 = new List<GameObject>();
	public List<GameObject> slot3 = new List<GameObject>();
	public List<GameObject> slot4 = new List<GameObject>();
	public List<GameObject> slot5 = new List<GameObject>();
	public List<GameObject> slot6 = new List<GameObject>();
	public List<GameObject> allWeapons = new List<GameObject>();

	public float killCharge;
	public Slider killMeter;

	public bool noWeapons = true;
	public int lastUsedSlot = 69;
	public int lastUsedVariation = 69;

	public float headShotComboTime;
	public int headshots;
	public GameObject[] gunPanel;

	 
	void Start() { }
	 
	void Update() { }
	private void FixedUpdate() { }
	public void SwitchWeapon(int target) { }
	public void SwitchWeapon(int target, List<GameObject> slot, bool lastUsed = false, bool scrolled = false) { }
	public void ForceWeapon(GameObject weapon) { }
	public void NoWeapon() { }
	public void YesWeapon() { }
	public void AddKill() { }
	public void ClearKills() { }
	public void UpdateWeaponList(bool firstTime = false) { }
	public void UpdateWeaponIcon(bool firstTime = false) { }}
