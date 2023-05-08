using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Railcannon : MonoBehaviour
{
	public int variation;
	public GameObject beam;
	public Transform shootPoint;
	public GameObject fullCharge;
	public GameObject fireSound;
	public WeaponIdentifier wid;

	[SerializeField] Light fullChargeLight;
	[SerializeField] ParticleSystem fullChargeParticles;

	private void Start() { }
	private void OnEnable() { }
	private void OnDisable() { }
	 
	void Update() { }
	void Shoot() { }
	void GetStuff() { }}
