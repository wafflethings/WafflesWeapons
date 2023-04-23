using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Zombie : MonoBehaviour
{

	public float health;
	public bool limp;
	public GameObject player;
	public NavMeshAgent nma;
	public Animator anim;
	public AudioClip[] hurtSounds;
	public float hurtSoundVol;
	public AudioClip deathSound;
	public float deathSoundVol;
	public AudioClip scream;
	public bool grounded;
	public Vector3 agentVelocity;

	public Material deadMaterial;
	public Material simplifiedMaterial;
	public Renderer smr;

	public GameObject chest;
	public bool chestExploding;
	public GameObject chestExplosionStuff;

	public bool attacking;
	public LayerMask lmask;

	public Transform target;
	public List<EnemyIdentifier> enemyTargets = new List<EnemyIdentifier>();
	public bool friendly;
	public EnemyIdentifier targetedEnemy;
	public bool stopped;

	public bool knockedBack;
	public float brakes;
	public float juggleWeight;
	public bool falling;
	public bool noFallDamage;

	public bool musicRequested;
	public bool variableSpeed;

	void UpdateBuff() { }
	void SetSpeed() { }
	void Start() { }
	void OnEnable() { }
	private void Update() { }
	private void FixedUpdate() { }
	public void KnockBack(Vector3 force) { }
	public void StopKnockBack() { }
	public void GetHurt(GameObject target, Vector3 force, float multiplier, float critMultiplier, GameObject sourceWeapon = null) { }
	public void GoLimp() { }
	public void ChestExplodeEnd() { }
	public void StopHealing() { }
	public void ChestExplosion(bool cut = false) { }
	public void Cut(GameObject target) { }}
