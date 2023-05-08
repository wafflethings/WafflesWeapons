using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleProjectile : MonoBehaviour
{
	public float speed;
	public LayerMask lmask;

	public GameObject lightningBolt;
	public GameObject lightningBolt2;
	public Material additive;

	public List<EnemyIdentifier> shootList = new List<EnemyIdentifier>();

	public bool enemy;
	public EnemyType safeType;

	public GameObject spawnEffect;
	public GameObject explosionEffect;

	 
	void Start() { }
	private void FixedUpdate() { }
	private void OnDisable() { }
	private void OnEnable() { }
	 
	void Update() { }
	void ShootRandomLightning() { }
	void ShootTargetLightning() { }
	public void Activate() { }
	void Collapse() { }
	public void FadeIn() { }
	public void Explode() { }}
