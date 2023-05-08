using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
	public AudioClip shootSound;
	public AudioClip shootSound2;
	public AudioClip clickSound;
	public AudioClip clickChargeSound;
	public AudioClip smackSound;
	public AudioClip pump1sound;
	public AudioClip pump2sound;

	public int variation;
	public GameObject bullet;
	public GameObject grenade;
	public float spread;

	public Transform[] shootPoints;
	public GameObject muzzleFlash;
	public SkinnedMeshRenderer heatSinkSMR;

	 
	public LayerMask shotgunZoneLayerMask;
	public Image sliderFill;
	 
	 

	public GameObject grenadeSoundBubble;
	public GameObject chargeSoundBubble;
	public GameObject explosion;
	public GameObject pumpChargeSound;
	public GameObject warningBeep;

	 
	void Start() { }
	private void OnDisable() { }
	 
	void Update() { }
	void UpdateMeter() { }
	void Shoot() { }
	void ShootSinks() { }
	void Pump() { }
	public void ReleaseHeat() { }
	public void ClickSound() { }
	public void ReadyGun() { }
	public void Smack() { }
	public void SkipShoot() { }
	public void Pump1Sound() { }
	public void Pump2Sound() { }}
