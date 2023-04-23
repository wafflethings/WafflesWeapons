using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class GunSetter : MonoSingleton<GunSetter>
{

	[Header("Revolver")]
	public GameObject[] revolverPierce;
	public GameObject[] revolverRicochet;
	public GameObject[] revolverBerserker;

	[Header("Shotgun")]
	public GameObject[] shotgunGrenade;
	public GameObject[] shotgunPump;
	public GameObject[] shotgunRed;

	[Header("Nailgun")]
	public GameObject[] nailMagnet;
	public GameObject[] nailOverheat;
	public GameObject[] nailRed;

	[Header("Railcannon")]
	public GameObject[] railCannon;
	public GameObject[] railHarpoon;
	public GameObject[] railMalicious;

	[Header("Rocket Launcher")]
	public GameObject[] rocketBlue;
	public GameObject[] rocketGreen;
	public GameObject[] rocketRed;

	 

	 
	void Start() { }
	public void ResetWeapons(bool firstTime = false) { }
	public void ForceWeapon(string weaponName) { }}
