using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class GunSetter : MonoSingleton<GunSetter>
{
	[HideInInspector]
	public GunControl gunc;

	[HideInInspector]
	public ForcedLoadout forcedLoadout;

	[Header("Revolver")]
	public AssetReference[] revolverPierce;

	public AssetReference[] revolverRicochet;

	public AssetReference[] revolverTwirl;

	[Header("Shotgun")]
	public AssetReference[] shotgunGrenade;

	public AssetReference[] shotgunPump;

	public AssetReference[] shotgunRed;

	[Header("Nailgun")]
	public AssetReference[] nailMagnet;

	public AssetReference[] nailOverheat;

	public AssetReference[] nailRed;

	[Header("Railcannon")]
	public AssetReference[] railCannon;

	public AssetReference[] railHarpoon;

	public AssetReference[] railMalicious;

	[Header("Rocket Launcher")]
	public AssetReference[] rocketBlue;

	public AssetReference[] rocketGreen;

	public AssetReference[] rocketRed;

	private void Prewarm(AssetReference[] prefabs)
	{
	}

	private new void Awake()
	{
	}

	private void Start()
	{
	}

	public void ResetWeapons(bool firstTime = false)
	{
	}

	private List<int> CheckWeaponOrder(string weaponType)
	{
		return null;
	}

	private void CheckWeapon(string name, List<GameObject> slot, GameObject[] prefabs)
	{
	}

	public void ForceWeapon(string weaponName)
	{
	}
}
