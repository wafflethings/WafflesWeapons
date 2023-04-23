using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
	public bool launchable = true;
	[SerializeField] public bool launched;
	[SerializeField] private GameObject breakEffect;
	public float damage;
	public float speed;
	public bool parry;
	public bool ghostCollider;
	public bool canBreakBeforeLaunched;

	[Header("Physics Cannonball Settings")]
	public bool physicsCannonball;	
	public AudioSource bounceSound;
	public int maxBounces;
	public int durability = 99;
	[SerializeField] GameObject interruptionExplosion;
	[SerializeField] GameObject groundHitShockwave;
	

	 
	void Start() { }
	void OnDestroy() { }
	private void FixedUpdate() { }
	public void Launch() { }
	public void Unlaunch(bool relaunchable = true) { }
	public void Collide(Collider other) { }
	public void Break() { }
	void Bounce() { }
	public void Explode() { }
	public void InstaBreakDefenceCancel() { }}
