using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Grenade : MonoBehaviour
{
	public string hitterWeapon;
	public GameObject sourceWeapon;
	public GameObject explosion;
	public GameObject harmlessExplosion;
	public GameObject superExplosion;
	public bool enemy;
	public bool rocket;
	public float rocketSpeed;
	public bool frozen {get;set;}	[SerializeField] GameObject freezeEffect;

	public bool playerRiding;
	public GameObject playerRideSound;

	private void Start() { }
	void OnDestroy() { }
	void Update() { }
	void FixedUpdate() { }
	private void LateUpdate() { }
	public void Collision(Collider other) { }
	public void Explode(bool big = false, bool harmless = false, bool super = false, float sizeMultiplier = 1, bool ultrabooster = false, GameObject exploderWeapon = null) { }
	public void PlayerRideStart() { }
	public void PlayerRideEnd() { }
	public void CanCollideWithPlayer(bool can = true) { }}
