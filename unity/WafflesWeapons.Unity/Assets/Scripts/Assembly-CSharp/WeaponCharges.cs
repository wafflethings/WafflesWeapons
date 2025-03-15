using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class WeaponCharges : MonoSingleton<WeaponCharges>
{
	private GunControl gc;

	public float rev0charge;

	public bool rev0alt;

	public float rev1charge;

	public float rev2charge;

	public bool rev2alt;

	public float shoAltNadeCharge;

	public float shoSawCharge;

	public int shoSawAmount;

	[HideInInspector]
	public bool nai0set;

	public float naiHeatsinks;

	public float naiSawHeatsinks;

	public float naiheatUp;

	public float naiAmmo;

	public float naiSaws;

	public bool naiAmmoDontCharge;

	[HideInInspector]
	public List<Magnet> magnets;

	public float naiMagnetCharge;

	public float naiZapperRecharge;

	public float raicharge;

	public GameObject railCannonFullChargeSound;

	public bool railChargePlayed;

	[HideInInspector]
	public bool rocketset;

	public float rocketcharge;

	[HideInInspector]
	public bool rocketFrozen;

	public float rocketFreezeTime;

	[HideInInspector]
	public RocketLauncher rocketLauncher;

	public int rocketCount;

	[HideInInspector]
	public bool canAutoUnfreeze;

	public TimeSince timeSinceIdleFrozen;

	public float rocketCannonballCharge;

	public float rocketNapalmFuel;

	[HideInInspector]
	public bool infiniteRocketRide;

	public float[] revaltpickupcharges;

	public float[] shoaltcooldowns;

	public float punchStamina;

	private void Update()
	{
	}

	public void Charge(float amount)
	{
	}

	public void MaxCharges()
	{
	}

	public void PlayRailCharge()
	{
	}

	public void ResetNailgunAmmo()
	{
	}
}
