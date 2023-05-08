using System.Collections;
using System.Collections.Generic;
 
using UnityEngine;
using UnityEngine.UI;

public class Nailgun : MonoBehaviour
{

	public int variation;
	public bool altVersion;

	public GameObject[] shootPoints;
	[SerializeField] private Renderer[] barrelHeats;
	public GameObject muzzleFlash;
	public GameObject muzzleFlash2;
	public AudioSource snapSound;

	public float fireRate;
	public GameObject nail;
	public GameObject heatedNail;
	public GameObject magnetNail;
	public float spread;

	[Header("Magnet")]
	public Text ammoText;
	public GameObject noAmmoSound;
	public GameObject lastShotSound;

	[Header("Overheat")]
	public Color emptyColor;
	public Color fullColor;
	public Image[] heatSinkImages;

	 
	void Start() { }
	private void OnDisable() { }
	private void OnEnable() { }
	 
	void Update() { }
	private void FixedUpdate() { }
	void UpdateAnimationWeight() { }
	void Shoot() { }
	public void BurstFire() { }
	public void SuperSaw() { }
	public void ShootMagnet() { }
	public void CanShoot() { }
	void MaxCharge() { }
	void RefreshHeatSinkFill(float charge, bool playSound = false) { }
	public void SnapSound() { }}
